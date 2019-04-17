using Disney.LaunchPadFramework;
using Foundation.Unity;
using System;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public class SkinnedMeshDefinition : MeshDefinition
	{
		public string RootBoneName;

		public string[] BoneNames;

		private bool UseGpuSkinning = false;

		public SkinnedMeshDefinition(bool useGpuSkinning = false)
		{
			this.UseGpuSkinning = useGpuSkinning;
		}

		public override Renderer CreateRenderer(GameObject go)
		{
			Renderer result;
			if (this.UseGpuSkinning)
			{
				result = go.AddComponent<MeshRenderer>();
				go.AddComponent<MeshFilter>();
				go.AddComponent<GpuSkinnedRenderer>();
			}
			else
			{
				result = go.AddComponent<SkinnedMeshRenderer>();
			}
			return result;
		}

		public override void ApplyMesh(GameObject go, Mesh overrideMesh = null)
		{
			Rig componentInParent = go.GetComponentInParent<Rig>();
			if (this.BoneNames == null)
			{
				Log.LogErrorFormatted(this, "BoneNames must be set before calling ApplyMesh", new object[0]);
			}
			else if (!componentInParent)
			{
				Log.LogErrorFormatted(this, "Rig component missing", new object[0]);
			}
			else
			{
				Transform[] array = new Transform[this.BoneNames.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = componentInParent[this.BoneNames[i]];
				}
				this.setSharedMesh(go, (overrideMesh != null) ? overrideMesh : this.Mesh);
				Transform rootBone = componentInParent[this.RootBoneName];
				this.SetBones(go, array, rootBone);
			}
		}

		public override void CleanUp(GameObject go)
		{
			ComponentExtensions.DestroyIfInstance(this.getSharedMesh(go));
			this.setSharedMesh(go, null);
			Material sharedMaterial = this.getSharedMaterial(go);
			if (sharedMaterial)
			{
				if (sharedMaterial.HasProperty("_MainTex"))
				{
					ComponentExtensions.DestroyIfInstance(sharedMaterial.mainTexture);
				}
				ComponentExtensions.DestroyIfInstance(sharedMaterial);
				this.setSharedMaterial(go, null);
			}
		}

		public override string ToString()
		{
			return string.Format("[SkinnedMesh] '{0}' RootBone={1}, #BoneNames={2}, Mesh: {3} [{4:x8}]", new object[]
			{
				this.Name,
				this.RootBoneName,
				(this.BoneNames != null) ? this.BoneNames.Length.ToString() : "-",
				(this.Mesh != null) ? this.Mesh.name : "-",
				(this.Mesh != null) ? this.Mesh.GetHash() : 0
			});
		}

		public override Material CreateCombinedMaterial(Texture atlas)
		{
			return new Material(this.UseGpuSkinning ? AvatarService.GpuCombinedMeshShader : AvatarService.CombinedMeshShader)
			{
				mainTexture = atlas
			};
		}

		private void setSharedMesh(GameObject go, Mesh mesh)
		{
			if (this.UseGpuSkinning)
			{
				MeshFilter component = go.GetComponent<MeshFilter>();
				component.sharedMesh = mesh;
			}
			else
			{
				SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
				component2.sharedMesh = mesh;
			}
		}

		private Mesh getSharedMesh(GameObject go)
		{
			Mesh sharedMesh;
			if (this.UseGpuSkinning)
			{
				MeshFilter component = go.GetComponent<MeshFilter>();
				sharedMesh = component.sharedMesh;
			}
			else
			{
				SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
				sharedMesh = component2.sharedMesh;
			}
			return sharedMesh;
		}

		private void setSharedMaterial(GameObject go, Material mat)
		{
			if (this.UseGpuSkinning)
			{
				MeshRenderer component = go.GetComponent<MeshRenderer>();
				component.sharedMaterial = mat;
			}
			else
			{
				SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
				component2.sharedMaterial = mat;
			}
		}

		private Material getSharedMaterial(GameObject go)
		{
			Material sharedMaterial;
			if (this.UseGpuSkinning)
			{
				MeshRenderer component = go.GetComponent<MeshRenderer>();
				sharedMaterial = component.sharedMaterial;
			}
			else
			{
				SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
				sharedMaterial = component2.sharedMaterial;
			}
			return sharedMaterial;
		}

		protected virtual void SetBones(GameObject go, Transform[] bones, Transform rootBone)
		{
			if (this.UseGpuSkinning)
			{
				GpuSkinnedRenderer component = go.GetComponent<GpuSkinnedRenderer>();
				component.init(bones, true);
			}
			else
			{
				SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
				component2.rootBone = rootBone;
				component2.bones = bones;
			}
		}
	}
}