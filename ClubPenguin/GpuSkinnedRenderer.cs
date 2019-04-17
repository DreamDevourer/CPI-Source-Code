using Disney.LaunchPadFramework;
using Foundation.Unity;
using System;
using UnityEngine;

namespace ClubPenguin
{
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class GpuSkinnedRenderer : MonoBehaviour
	{
		private struct BindPose
		{
			public Quaternion q;

			public Vector3 p;

			public BindPose(Quaternion _q, Vector3 _p)
			{
				this.q = _q;
				this.p = _p;
			}
		}

		private const int MAX_BONES = 48;

		private Transform[] m_Bones;

		private GpuSkinnedRenderer.BindPose[] m_BindPose;

		private Vector4[] m_BonesQuat;

		private Vector4[] m_BonesPos;

		private int m_QuatUniform;

		private int m_PosUniform;

		private Material m_Material;

		public void init(Transform[] bones, bool calculateWeights = false)
		{
			this.m_Bones = bones;
			this.setMaterial();
			this.m_QuatUniform = Shader.PropertyToID("bonequat");
			this.m_PosUniform = Shader.PropertyToID("bonepos");
			Mesh sharedMesh = base.GetComponent<MeshFilter>().sharedMesh;
			this.computeBindPoses(sharedMesh);
			if (calculateWeights)
			{
				GpuSkinnedRenderer.storeWeightsInTangents(sharedMesh);
			}
		}

		private void setMaterial()
		{
			MeshRenderer component = base.GetComponent<MeshRenderer>();
			component.material = component.material;
			this.m_Material = component.material;
		}

		public void OnDestroy()
		{
			if (this.m_Material != null)
			{
				ComponentExtensions.DestroyIfInstance(this.m_Material);
				this.m_Material = null;
			}
		}

		public void LateUpdate()
		{
			if (this.m_Bones != null)
			{
				int num = this.m_Bones.Length;
				for (int i = 0; i < num; i++)
				{
					Transform transform = this.m_Bones[i];
					Quaternion rotation = transform.rotation;
					Vector3 position = transform.position;
					Quaternion quaternion = rotation * this.m_BindPose[i].q;
					Vector3 vector = rotation * this.m_BindPose[i].p + position;
					this.m_BonesQuat[i] = new Vector4(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
					this.m_BonesPos[i] = new Vector4(vector.x, vector.y, vector.z, 1f);
				}
				if (this.m_Material == null)
				{
					this.setMaterial();
				}
				this.m_Material.SetVectorArray(this.m_QuatUniform, this.m_BonesQuat);
				this.m_Material.SetVectorArray(this.m_PosUniform, this.m_BonesPos);
			}
		}

		private void computeBindPoses(Mesh mesh)
		{
			Matrix4x4[] bindposes = mesh.bindposes;
			int num = bindposes.Length;
			if (num > 48)
			{
				Log.LogErrorFormatted(this, "Invalid mesh {0} with too many bones {1} > {2}", new object[]
				{
					mesh.name,
					num,
					48
				});
			}
			else
			{
				this.m_BindPose = new GpuSkinnedRenderer.BindPose[num];
				this.m_BonesQuat = new Vector4[num];
				this.m_BonesPos = new Vector4[num];
				for (int i = 0; i < num; i++)
				{
					Vector3 p = bindposes[i].GetColumn(3);
					Quaternion q = Quaternion.LookRotation(bindposes[i].GetColumn(2), bindposes[i].GetColumn(1));
					this.m_BindPose[i] = new GpuSkinnedRenderer.BindPose(q, p);
				}
			}
		}

		public static void storeWeightsInTangents(Mesh mesh)
		{
			int vertexCount = mesh.vertexCount;
			Vector4[] array = new Vector4[vertexCount];
			BoneWeight[] boneWeights = mesh.boneWeights;
			for (int i = 0; i < vertexCount; i++)
			{
				BoneWeight boneWeight = boneWeights[i];
				array[i] = GpuSkinnedRenderer.packInfluences(boneWeight);
			}
			mesh.tangents = array;
		}

		private static Vector4 packInfluences(BoneWeight boneWeight)
		{
			return new Vector4((float)boneWeight.boneIndex0 + boneWeight.weight0 * 0.5f, (float)boneWeight.boneIndex1 + boneWeight.weight1 * 0.5f, (float)boneWeight.boneIndex2 + boneWeight.weight2 * 0.5f, (float)boneWeight.boneIndex3 + boneWeight.weight3 * 0.5f);
		}
	}
}