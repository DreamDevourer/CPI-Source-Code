using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public class BakeMaterialProperties : BaseMaterialProperties
	{
		public float AtlasOffsetU;

		public float AtlasOffsetV;

		public float AtlasOffsetScaleU;

		public float AtlasOffsetScaleV;

		public BakeMaterialProperties(Material mat = null)
		{
			if (mat != null)
			{
				this.AtlasOffsetU = mat.GetFloat(ShaderParams.ATLAS_OFFSET_U);
				this.AtlasOffsetV = mat.GetFloat(ShaderParams.ATLAS_OFFSET_V);
				this.AtlasOffsetScaleU = mat.GetFloat(ShaderParams.ATLAS_OFFSET_SCALE_U);
				this.AtlasOffsetScaleV = mat.GetFloat(ShaderParams.ATLAS_OFFSET_SCALE_V);
			}
		}

		public override void Apply(Material mat)
		{
			mat.SetFloat(ShaderParams.ATLAS_OFFSET_U, this.AtlasOffsetU);
			mat.SetFloat(ShaderParams.ATLAS_OFFSET_V, this.AtlasOffsetV);
			mat.SetFloat(ShaderParams.ATLAS_OFFSET_SCALE_U, this.AtlasOffsetScaleU);
			mat.SetFloat(ShaderParams.ATLAS_OFFSET_SCALE_V, this.AtlasOffsetScaleV);
		}

		public override List<Object> InternalReferences()
		{
			return new List<Object>();
		}

		public override string ToString()
		{
			return string.Format("[BakeMaterial : AtlasOffsetU={0}, AtlasOffsetV={1}, AtlasOffsetScaleU={2}, AtlasOffsetScaleV={3}", new object[]
			{
				this.AtlasOffsetU,
				this.AtlasOffsetV,
				this.AtlasOffsetScaleU,
				this.AtlasOffsetScaleV
			});
		}
	}
}