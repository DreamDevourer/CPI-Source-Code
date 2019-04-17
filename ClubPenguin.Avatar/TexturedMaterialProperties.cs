using System;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	public abstract class TexturedMaterialProperties : BaseMaterialProperties
	{
		private static Material bakeMaterial;

		protected static Material GetBakeMaterial(Shader shader)
		{
			if (!TexturedMaterialProperties.bakeMaterial)
			{
				TexturedMaterialProperties.bakeMaterial = new Material(shader);
			}
			else
			{
				TexturedMaterialProperties.bakeMaterial.shader = shader;
			}
			return TexturedMaterialProperties.bakeMaterial;
		}

		public abstract Vector2 GetTextureSize();

		public abstract Texture GetMaskTexture();

		public abstract Material GetMaterial(bool baking);

		public abstract void ResetMaterial(Material mat);
	}
}