using System;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	public static class ShaderParams
	{
		public const int MAX_DECAL_CHANNELS = 6;

		public static readonly int[] DECAL_TEX;

		public static readonly int[] DECAL_COLOR;

		public static readonly int[] DECAL_SCALE;

		public static readonly int[] DECAL_U_OFFSET;

		public static readonly int[] DECAL_V_OFFSET;

		public static readonly int[] DECAL_REPEAT;

		public static readonly int[] DECAL_ROTATION_RADS;

		public static readonly int ATLAS_OFFSET_U;

		public static readonly int ATLAS_OFFSET_V;

		public static readonly int ATLAS_OFFSET_SCALE_U;

		public static readonly int ATLAS_OFFSET_SCALE_V;

		public static readonly int BODY_RED_CHANNEL_COLOR;

		public static readonly int BODY_GREEN_CHANNEL_COLOR;

		public static readonly int BODY_BLUE_CHANNEL_COLOR;

		public static readonly int DIFFUSE_TEX;

		public static readonly int BODY_COLORS_MASK_TEX;

		public static readonly int DETAIL_MATCAPMASK_EMISSIVE_TEX;

		public static readonly int DECALS_123_OPACITY_TEX;

		public static readonly int EMISSIVE_COLOR_TINT;

		static ShaderParams()
		{
			ShaderParams.DECAL_TEX = new int[6];
			ShaderParams.DECAL_COLOR = new int[6];
			ShaderParams.DECAL_SCALE = new int[6];
			ShaderParams.DECAL_U_OFFSET = new int[6];
			ShaderParams.DECAL_V_OFFSET = new int[6];
			ShaderParams.DECAL_REPEAT = new int[6];
			ShaderParams.DECAL_ROTATION_RADS = new int[6];
			ShaderParams.ATLAS_OFFSET_U = Shader.PropertyToID("_AtlasOffsetU");
			ShaderParams.ATLAS_OFFSET_V = Shader.PropertyToID("_AtlasOffsetV");
			ShaderParams.ATLAS_OFFSET_SCALE_U = Shader.PropertyToID("_AtlasOffsetScaleU");
			ShaderParams.ATLAS_OFFSET_SCALE_V = Shader.PropertyToID("_AtlasOffsetScaleV");
			ShaderParams.BODY_RED_CHANNEL_COLOR = Shader.PropertyToID("_BodyRedChannelColor");
			ShaderParams.BODY_GREEN_CHANNEL_COLOR = Shader.PropertyToID("_BodyGreenChannelColor");
			ShaderParams.BODY_BLUE_CHANNEL_COLOR = Shader.PropertyToID("_BodyBlueChannelColor");
			ShaderParams.DIFFUSE_TEX = Shader.PropertyToID("_Diffuse");
			ShaderParams.BODY_COLORS_MASK_TEX = Shader.PropertyToID("_BodyColorsMaskTex");
			ShaderParams.DETAIL_MATCAPMASK_EMISSIVE_TEX = Shader.PropertyToID("_DetailAndMatcapMaskAndEmissive");
			ShaderParams.DECALS_123_OPACITY_TEX = Shader.PropertyToID("_Decal123OpacityTex");
			ShaderParams.EMISSIVE_COLOR_TINT = Shader.PropertyToID("_EmissiveColorTint");
			for (int i = 0; i < 6; i++)
			{
				string str = "_Decal" + (i + 1);
				ShaderParams.DECAL_TEX[i] = Shader.PropertyToID(str + "Tex");
				ShaderParams.DECAL_COLOR[i] = Shader.PropertyToID(str + "Color");
				ShaderParams.DECAL_SCALE[i] = Shader.PropertyToID(str + "Scale");
				ShaderParams.DECAL_U_OFFSET[i] = Shader.PropertyToID(str + "UOffset");
				ShaderParams.DECAL_V_OFFSET[i] = Shader.PropertyToID(str + "VOffset");
				ShaderParams.DECAL_REPEAT[i] = Shader.PropertyToID(str + "Repeat");
				ShaderParams.DECAL_ROTATION_RADS[i] = Shader.PropertyToID(str + "RotationRads");
			}
		}
	}
}