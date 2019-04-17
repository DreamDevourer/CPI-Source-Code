using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public class BodyMaterialProperties : TexturedMaterialProperties
	{
		public Texture2D DiffuseTexture;

		public Texture2D BodyColorsMaskTexture;

		public Texture2D DetailMatCapMaskEmissiveTexture;

		private static readonly BodyMaterialProperties DefaultProperties = new BodyMaterialProperties();

		public BodyMaterialProperties()
		{
		}

		public BodyMaterialProperties(Texture2D diffuseTexture, Texture2D bodyColorsMaskTexture, Texture2D detailMatCapMaskEmissiveTexture)
		{
			this.DiffuseTexture = diffuseTexture;
			this.BodyColorsMaskTexture = bodyColorsMaskTexture;
			this.DetailMatCapMaskEmissiveTexture = detailMatCapMaskEmissiveTexture;
		}

		public override void Apply(Material mat)
		{
			mat.SetTexture(ShaderParams.DIFFUSE_TEX, this.DiffuseTexture);
			mat.SetTexture(ShaderParams.BODY_COLORS_MASK_TEX, this.BodyColorsMaskTexture);
			mat.SetTexture(ShaderParams.DETAIL_MATCAPMASK_EMISSIVE_TEX, this.DetailMatCapMaskEmissiveTexture);
		}

		public override Vector2 GetTextureSize()
		{
			Vector2 result;
			if (this.BodyColorsMaskTexture)
			{
				result = new Vector2((float)this.BodyColorsMaskTexture.width, (float)this.BodyColorsMaskTexture.height);
			}
			else if (this.DiffuseTexture)
			{
				result = new Vector2((float)this.DiffuseTexture.width, (float)this.DiffuseTexture.height);
			}
			else if (this.DetailMatCapMaskEmissiveTexture)
			{
				result = new Vector2((float)this.DetailMatCapMaskEmissiveTexture.width, (float)this.DetailMatCapMaskEmissiveTexture.height);
			}
			else
			{
				result = Vector2.zero;
			}
			return result;
		}

		public override Texture GetMaskTexture()
		{
			return this.BodyColorsMaskTexture;
		}

		public override Material GetMaterial(bool baking)
		{
			Material result;
			if (baking)
			{
				result = TexturedMaterialProperties.GetBakeMaterial(AvatarService.BodyBakeShader);
			}
			else
			{
				result = new Material(AvatarService.BodyPreviewShader);
			}
			return result;
		}

		public override void ResetMaterial(Material mat)
		{
			BodyMaterialProperties.DefaultProperties.Apply(mat);
		}

		public override List<Object> InternalReferences()
		{
			return new List<Object>
			{
				this.DiffuseTexture,
				this.BodyColorsMaskTexture,
				this.DetailMatCapMaskEmissiveTexture
			};
		}

		public override string ToString()
		{
			return string.Format("[BodyMaterial : DiffuseTexture={0}, BodyColorsMaskTexture={1}, DetailMatCapMaskEmissiveTexture={2}", this.DiffuseTexture, this.BodyColorsMaskTexture, this.DetailMatCapMaskEmissiveTexture);
		}
	}
}