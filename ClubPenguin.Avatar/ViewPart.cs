using Disney.LaunchPadFramework;
using Foundation.Unity;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	public class ViewPart
	{
		private DecalMaterialProperties[] DecalMaterialsProps;

		private DecalMaterialProperties[] defaultDecalMaterialsProps;

		private List<TexturedMaterialProperties> TexturedMaterialProps;

		private MeshDefinition MeshDef;

		public void ResetMaterialProperties(Material mat)
		{
			if (this.TexturedMaterialProps != null)
			{
				for (int i = 0; i < this.TexturedMaterialProps.Count; i++)
				{
					this.TexturedMaterialProps[i].ResetMaterial(mat);
				}
			}
			if (this.DecalMaterialsProps != null)
			{
				for (int i = 0; i < this.DecalMaterialsProps.Length; i++)
				{
					this.DecalMaterialsProps[i].ResetMaterial(mat);
				}
			}
		}

		public void ApplyMaterialProperties(Material mat)
		{
			if (this.TexturedMaterialProps != null)
			{
				for (int i = 0; i < this.TexturedMaterialProps.Count; i++)
				{
					this.TexturedMaterialProps[i].Apply(mat);
				}
			}
			if (this.DecalMaterialsProps != null)
			{
				for (int i = 0; i < this.DecalMaterialsProps.Length; i++)
				{
					this.DecalMaterialsProps[i].Apply(mat);
				}
			}
		}

		public bool HasMaterialProperties(Type type)
		{
			bool flag = false;
			int num = 0;
			while (!flag && num < this.TexturedMaterialProps.Count)
			{
				flag = type.IsInstanceOfType(this.TexturedMaterialProps[num]);
				num++;
			}
			return flag;
		}

		public Material GetMaterial(bool baking = false)
		{
			int num = (this.TexturedMaterialProps != null) ? (this.TexturedMaterialProps.Count - 1) : (-1);
			Material material = null;
			int num2 = num;
			while (num2 >= 0 && !material)
			{
				material = this.TexturedMaterialProps[num2].GetMaterial(baking);
				num2--;
			}
			return material;
		}

		public Texture GetMaskTexture()
		{
			int num = (this.TexturedMaterialProps != null) ? (this.TexturedMaterialProps.Count - 1) : (-1);
			Texture texture = null;
			int num2 = num;
			while (num2 >= 0 && !texture)
			{
				texture = this.TexturedMaterialProps[num2].GetMaskTexture();
				num2--;
			}
			return texture;
		}

		public Vector2 GetTextureSize()
		{
			int num = (this.TexturedMaterialProps != null) ? (this.TexturedMaterialProps.Count - 1) : 0;
			Vector2 vector = Vector2.zero;
			int num2 = num;
			while (num2 >= 0 && Vector2.zero.Equals(vector))
			{
				vector = this.TexturedMaterialProps[num2].GetTextureSize();
				num2--;
			}
			return vector;
		}

		public Mesh GetMesh()
		{
			return this.MeshDef.Mesh;
		}

		public string[] GetBoneNames()
		{
			SkinnedMeshDefinition skinnedMeshDefinition = this.MeshDef as SkinnedMeshDefinition;
			string[] result;
			if (skinnedMeshDefinition == null)
			{
				result = null;
			}
			else
			{
				result = skinnedMeshDefinition.BoneNames;
			}
			return result;
		}

		public void SetupRenderer(GameObject gameObject, AvatarModel model, ref Renderer rend)
		{
			if (rend == null)
			{
				rend = this.MeshDef.CreateRenderer(gameObject);
				model.Definition.RenderProperties.Apply(rend);
			}
			Material material = this.GetMaterial(false);
			BodyColorMaterialProperties bodyColorMaterialProperties = new BodyColorMaterialProperties(model.BeakColor, model.BellyColor, model.BodyColor);
			bodyColorMaterialProperties.Apply(material);
			this.ApplyMaterialProperties(material);
			ComponentExtensions.DestroyIfInstance(rend.sharedMaterial);
			rend.sharedMaterial = material;
			this.MeshDef.ApplyMesh(gameObject, null);
		}

		public void CleanUp(GameObject go)
		{
			Renderer component = go.GetComponent<Renderer>();
			if (component != null)
			{
				ComponentExtensions.DestroyIfInstance(component.sharedMaterial);
				if (this.MeshDef != null)
				{
					this.MeshDef.CleanUp(go);
				}
			}
		}

		public void SetMeshDefinition(MeshDefinition def)
		{
			this.MeshDef = def;
		}

		public void InitMaterialProps()
		{
			this.TexturedMaterialProps = new List<TexturedMaterialProperties>(2);
		}

		public void AddMaterialProps(TexturedMaterialProperties texturedMatProps)
		{
			this.TexturedMaterialProps.Add(texturedMatProps);
		}

		public void InitDecalProps(int numDecals)
		{
			if (numDecals <= 0)
			{
				this.DecalMaterialsProps = null;
			}
			else
			{
				this.DecalMaterialsProps = new DecalMaterialProperties[numDecals];
			}
		}

		public void SetDecalProps(int idx, DecalMaterialProperties decalMatProps)
		{
			if (this.DecalMaterialsProps == null || idx >= this.DecalMaterialsProps.Length)
			{
				Log.LogErrorFormatted(this, "Decal index {0} is invalid!", new object[]
				{
					idx
				});
			}
			else
			{
				this.DecalMaterialsProps[idx] = decalMatProps;
			}
		}

		public void SetDefaultProps(DecalMaterialProperties[] decalMatProps)
		{
			this.defaultDecalMaterialsProps = new DecalMaterialProperties[decalMatProps.Length];
			this.defaultDecalMaterialsProps = decalMatProps;
		}

		public DecalMaterialProperties[] GetDefaultDecalProps()
		{
			return this.defaultDecalMaterialsProps;
		}
	}
}