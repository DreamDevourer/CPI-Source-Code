using ClubPenguin.Core;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.BlobShadows
{
	public class BlobShadowRenderer : MonoBehaviour
	{
		private const string BLOB_SHADOW_CAM_POSITION_PROP = "_ShadowPlaneWorldPos";

		private const string SHADOW_BOX_DIMENSION_PROP = "_ShadowPlaneDim";

		private const string RENDER_TEX_DIMENSION_PROP = "_ShadowTextureDim";

		private const string BLOB_SHADOW_TEX_PROP = "_BlobShadowTex";

		private const string BLOB_SHADOWS_ACTIVE_PROP = "_BlobShadowsActive";

		private const string BLOB_SHADOW_CAM_VP = "_blobShadowCamVp";

		private const float HEIGHT_OFFSET = 5f;

		private const float MAIN_CAM_TO_CENTER_RATIO = 0.45f;

		private int BLOB_SHADOW_CAM_POSITION_PROP_ID = 0;

		private int BLOB_SHADOW_CAM_VP_ID = 0;

		public float ShadowBoxDimension = 32f;

		public int RenderTextureDimension = 128;

		public Texture2D ShadowTexture = null;

		[HideInInspector]
		public List<BlobShadowCaster> ShadowCasters = new List<BlobShadowCaster>();

		public bool BlobShadowsSupported = true;

		private Transform transformRef;

		private RenderTexture shadowRenderTexture;

		private Camera prevMainCam;

		private Transform mainCamTrans;

		private Dictionary<Material, Material> replacementMats;

		private EventDispatcher eventDispatcher;

		private Matrix4x4 projectionMatrix;

		private Vector3[] startingVertices;

		private Vector2[] startingUv;

		private Vector3[] shadowVertices;

		private Vector2[] shadowUv;

		private int[] shadowTriangles;

		private Mesh shadowMesh;

		private Material shadowMaterial;

		private int shadowCasterCount;

		private Vector4 blobShadowPosition;

		public bool IsShadowsVisible
		{
			get;
			private set;
		}

		private void Awake()
		{
			if (Object.FindObjectsOfType<BlobShadowRenderer>().Length > 1)
			{
				throw new Exception("A scene should only contain 1 BlobShadowRenderer.");
			}
			SceneRefs.Set<BlobShadowRenderer>(this);
		}

		private void Start()
		{
			if (this.BlobShadowsSupported)
			{
				this.startingVertices = new Vector3[]
				{
					new Vector3(0.5f, 0f, 0.5f),
					new Vector3(0.5f, 0f, -0.5f),
					new Vector3(-0.5f, 0f, -0.5f),
					new Vector3(-0.5f, 0f, 0.5f)
				};
				this.startingUv = new Vector2[]
				{
					new Vector2(0f, 0f),
					new Vector2(0f, 1f),
					new Vector2(1f, 1f),
					new Vector2(1f, 0f)
				};
				this.shadowVertices = new Vector3[0];
				this.shadowUv = new Vector2[0];
				this.shadowTriangles = new int[0];
				this.shadowMesh = new Mesh();
				this.shadowMaterial = new Material(Shader.Find("CpRemix/BlobShadows/ShadowGeoShader"));
				this.shadowMaterial.SetTexture("_MainTex", this.ShadowTexture);
				this.IsShadowsVisible = true;
				this.transformRef = base.transform;
				this.projectionMatrix = Matrix4x4.Ortho(-0.5f, 0.5f, -0.5f, 0.5f, 0.3f, 1000f);
				Vector4 row = this.projectionMatrix.GetRow(0);
				row.x /= this.ShadowBoxDimension;
				this.projectionMatrix.SetRow(0, row);
				row = this.projectionMatrix.GetRow(1);
				row.y /= this.ShadowBoxDimension;
				this.projectionMatrix.SetRow(1, row);
				string graphicsDeviceVersion = SystemInfo.graphicsDeviceVersion;
				if (Application.platform == RuntimePlatform.WindowsEditor || graphicsDeviceVersion.IndexOf("OpenGL") <= -1)
				{
					for (int i = 0; i < 4; i++)
					{
						this.projectionMatrix[1, i] = -this.projectionMatrix[1, i];
						this.projectionMatrix[2, i] = this.projectionMatrix[2, i] * 0.5f + this.projectionMatrix[3, i] * 0.5f;
					}
				}
				this.blobShadowPosition = default(Vector4);
				this.BLOB_SHADOW_CAM_POSITION_PROP_ID = Shader.PropertyToID("_ShadowPlaneWorldPos");
				this.BLOB_SHADOW_CAM_VP_ID = Shader.PropertyToID("_blobShadowCamVp");
				this.setupRenderTexture();
				this.enforceDownwardLook();
				this.setupShadowReceiverMaterials();
			}
			this.eventDispatcher = Service.Get<EventDispatcher>();
			this.eventDispatcher.AddListener<BlobShadowEvents.DisableBlobShadows>(new EventHandlerDelegate<BlobShadowEvents.DisableBlobShadows>(this.onDisableBlobShadows), EventDispatcher.Priority.DEFAULT);
			this.eventDispatcher.AddListener<BlobShadowEvents.EnableBlobShadows>(new EventHandlerDelegate<BlobShadowEvents.EnableBlobShadows>(this.onEnableBlobShadows), EventDispatcher.Priority.DEFAULT);
		}

		private void setupExistingShadowCasters()
		{
			BlobShadowCaster[] array = Object.FindObjectsOfType<BlobShadowCaster>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetBlobShadowCam(this);
				if (!this.ShadowCasters.Contains(array[i]))
				{
					this.ShadowCasters.Add(array[i]);
				}
			}
		}

		private void setupRenderTexture()
		{
			RenderTextureFormat format = RenderTextureFormat.ARGBHalf;
			if (!SystemInfo.SupportsRenderTextureFormat(format))
			{
				format = RenderTextureFormat.ARGB32;
			}
			this.shadowRenderTexture = new RenderTexture(this.RenderTextureDimension, this.RenderTextureDimension, 0, format);
			this.shadowRenderTexture.name = "Blob Shadow RenderTexture: " + base.name;
			this.shadowRenderTexture.useMipMap = false;
			this.shadowRenderTexture.Create();
		}

		private void enforceDownwardLook()
		{
			this.transformRef.up = Vector3.forward;
			this.transformRef.forward = Vector3.down;
		}

		public void RenderBlobs()
		{
			if (this.BlobShadowsSupported)
			{
				Graphics.SetRenderTarget(this.shadowRenderTexture);
				GL.Clear(false, true, Color.white);
				GL.LoadOrtho();
				GL.LoadIdentity();
				Matrix4x4 worldToLocalMatrix = this.transformRef.worldToLocalMatrix;
				Vector4 row = worldToLocalMatrix.GetRow(2);
				row.y = -row.y;
				row.w = -row.w;
				worldToLocalMatrix.SetRow(2, row);
				Matrix4x4 value = this.projectionMatrix * worldToLocalMatrix;
				this.shadowMaterial.SetMatrix(this.BLOB_SHADOW_CAM_VP_ID, value);
				this.shadowMaterial.SetPass(0);
				int num = 0;
				int count = this.ShadowCasters.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.ShadowCasters[i].GeoVisible)
					{
						num++;
					}
				}
				if (num != this.shadowCasterCount)
				{
					Array.Resize<Vector3>(ref this.shadowVertices, num * 4);
					Array.Resize<Vector2>(ref this.shadowUv, num * 4);
					Array.Resize<int>(ref this.shadowTriangles, num * 6);
					for (int i = this.shadowCasterCount; i < num; i++)
					{
						int num2 = i * 4;
						int num3 = i * 6;
						for (int j = 0; j < 4; j++)
						{
							this.shadowUv[num2 + j] = this.startingUv[j];
						}
						this.shadowTriangles[num3] = num2;
						this.shadowTriangles[num3 + 1] = num2 + 1;
						this.shadowTriangles[num3 + 2] = num2 + 2;
						this.shadowTriangles[num3 + 3] = num2;
						this.shadowTriangles[num3 + 4] = num2 + 2;
						this.shadowTriangles[num3 + 5] = num2 + 3;
					}
					this.shadowCasterCount = num;
					this.shadowMesh.Clear();
					this.shadowMesh.vertices = this.shadowVertices;
					this.shadowMesh.uv = this.shadowUv;
					this.shadowMesh.triangles = this.shadowTriangles;
				}
				int num4 = 0;
				for (int i = 0; i < count; i++)
				{
					if (this.ShadowCasters[i].GeoVisible)
					{
						int num5 = num4 * 4;
						Quaternion rotation = this.ShadowCasters[i].transform.rotation;
						Vector3 position = this.ShadowCasters[i].transform.position;
						float scaleX = this.ShadowCasters[i].ScaleX;
						float scaleZ = this.ShadowCasters[i].ScaleZ;
						for (int j = 0; j < 4; j++)
						{
							this.shadowVertices[num5 + j] = new Vector3(this.startingVertices[j].x * scaleX, this.startingVertices[j].y, this.startingVertices[j].z * scaleZ);
							this.shadowVertices[num5 + j] = rotation * this.shadowVertices[num5 + j] + position;
						}
						num4++;
					}
				}
				this.shadowMesh.vertices = this.shadowVertices;
				Graphics.DrawMeshNow(this.shadowMesh, Matrix4x4.identity);
				Graphics.SetRenderTarget(null);
			}
		}

		private void Update()
		{
			if (this.BlobShadowsSupported)
			{
				Camera main = Camera.main;
				if (!(main == null))
				{
					if (this.prevMainCam != main)
					{
						main.gameObject.AddComponent<BlobShadowCameraController>();
						this.mainCamTrans = main.transform;
						this.prevMainCam = main;
					}
					Vector3 vector = this.updatePosition(this.mainCamTrans);
					bool flag = vector != this.transformRef.position;
					if (flag)
					{
						if (flag)
						{
							this.updateShaderBlobCamPos(vector);
						}
						this.transformRef.position = vector;
					}
				}
			}
		}

		private void updateShaderBlobCamPos(Vector3 newCamPosition)
		{
			this.blobShadowPosition.Set(newCamPosition.x, newCamPosition.y, newCamPosition.z, 0f);
			Shader.SetGlobalVector(this.BLOB_SHADOW_CAM_POSITION_PROP_ID, this.blobShadowPosition);
		}

		private Vector3 updatePosition(Transform mainCamTrans)
		{
			Vector3 position = mainCamTrans.position;
			Vector3 forward = mainCamTrans.forward;
			Vector2 vector = new Vector2(forward.x, forward.z);
			vector.Normalize();
			position.y += 5f;
			position.x += vector.x * this.ShadowBoxDimension * 0.45f;
			position.z += vector.y * this.ShadowBoxDimension * 0.45f;
			return position;
		}

		private void setupShadowReceiverMaterials()
		{
			Shader.SetGlobalFloat("_ShadowPlaneDim", this.ShadowBoxDimension);
			Shader.SetGlobalFloat("_ShadowTextureDim", (float)this.RenderTextureDimension);
			this.replacementMats = new Dictionary<Material, Material>();
			Renderer[] array = Object.FindObjectsOfType<Renderer>();
			for (int i = 0; i < array.Length; i++)
			{
				Renderer renderer = array[i];
				Material sharedMaterial = renderer.sharedMaterial;
				if (sharedMaterial != null && sharedMaterial.HasProperty("_BlobShadowTex"))
				{
					Material material;
					if (!this.replacementMats.ContainsKey(sharedMaterial))
					{
						material = new Material(sharedMaterial);
						material.name = sharedMaterial.name + "_runtimeReplacement";
						material.SetTexture("_BlobShadowTex", this.shadowRenderTexture);
						this.replacementMats.Add(sharedMaterial, material);
					}
					else
					{
						material = this.replacementMats[sharedMaterial];
					}
					renderer.sharedMaterial = material;
				}
			}
		}

		private bool onEnableBlobShadows(BlobShadowEvents.EnableBlobShadows evt)
		{
			this.IsShadowsVisible = true;
			return false;
		}

		private bool onDisableBlobShadows(BlobShadowEvents.DisableBlobShadows evt)
		{
			this.IsShadowsVisible = false;
			return false;
		}

		private void OnDestroy()
		{
			this.eventDispatcher.RemoveListener<BlobShadowEvents.DisableBlobShadows>(new EventHandlerDelegate<BlobShadowEvents.DisableBlobShadows>(this.onDisableBlobShadows));
			this.eventDispatcher.RemoveListener<BlobShadowEvents.EnableBlobShadows>(new EventHandlerDelegate<BlobShadowEvents.EnableBlobShadows>(this.onEnableBlobShadows));
			if (this.replacementMats != null)
			{
				foreach (KeyValuePair<Material, Material> current in this.replacementMats)
				{
					Object.Destroy(current.Value);
				}
			}
		}
	}
}