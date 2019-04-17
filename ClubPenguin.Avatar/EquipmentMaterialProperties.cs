using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public class EquipmentMaterialProperties : TexturedMaterialProperties
	{
		public const int NUM_DECAL_COLORS = 6;

		public Texture Decals123OpacityTexture;

		public Color EmissiveColorTint;

		public Color[] DecalColors;

		private static readonly EquipmentMaterialProperties DefaultProperties = new EquipmentMaterialProperties();

		public EquipmentMaterialProperties()
		{
			this.Decals123OpacityTexture = null;
			this.EmissiveColorTint = Color.white;
			this.DecalColors = new Color[6];
			for (int i = 0; i < 6; i++)
			{
				this.DecalColors[i] = Color.white;
			}
		}

		public EquipmentMaterialProperties(Texture decals123OpacityTexture, Color emissiveColorTint, Color[] decalColors)
		{
			this.Decals123OpacityTexture = decals123OpacityTexture;
			this.EmissiveColorTint = emissiveColorTint;
			this.DecalColors = decalColors;
		}

		public override void Apply(Material mat)
		{
			mat.SetTexture(ShaderParams.DECALS_123_OPACITY_TEX, this.Decals123OpacityTexture);
			mat.SetColor(ShaderParams.EMISSIVE_COLOR_TINT, this.EmissiveColorTint);
			for (int i = 0; i < 6; i++)
			{
				mat.SetColor(ShaderParams.DECAL_COLOR[i], this.DecalColors[i]);
			}
		}

		public override Vector2 GetTextureSize()
		{
			Vector2 result;
			if (this.Decals123OpacityTexture)
			{
				result = new Vector2((float)this.Decals123OpacityTexture.width, (float)this.Decals123OpacityTexture.height);
			}
			else
			{
				result = Vector2.zero;
			}
			return result;
		}

		public override Texture GetMaskTexture()
		{
			return this.Decals123OpacityTexture;
		}

		public override Material GetMaterial(bool baking)
		{
			Material result;
			if (baking)
			{
				result = TexturedMaterialProperties.GetBakeMaterial(AvatarService.EquipmentBakeShader);
			}
			else
			{
				result = new Material(AvatarService.EquipmentPreviewShader);
			}
			return result;
		}

		public override void ResetMaterial(Material mat)
		{
			EquipmentMaterialProperties.DefaultProperties.Apply(mat);
		}

		public override List<Object> InternalReferences()
		{
			return new List<Object>
			{
				this.Decals123OpacityTexture
			};
		}

		public override string ToString()
		{
			return string.Format("[EquipmentMaterial : Decals123OpacityTexture={0}, EmissiveColorTint={1}]", this.Decals123OpacityTexture, this.EmissiveColorTint);
		}
	}
}