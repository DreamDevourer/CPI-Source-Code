using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public class DecalMaterialProperties : BaseMaterialProperties
	{
		public readonly int Channel;

		public Texture2D Texture;

		public float Scale;

		public float UOffset;

		public float VOffset;

		public bool Repeat;

		public float RotationRads;

		private static readonly DecalMaterialProperties[] DefaultProperties = new DecalMaterialProperties[]
		{
			new DecalMaterialProperties(0),
			new DecalMaterialProperties(1),
			new DecalMaterialProperties(2),
			new DecalMaterialProperties(3),
			new DecalMaterialProperties(4),
			new DecalMaterialProperties(5)
		};

		public DecalMaterialProperties(int channel)
		{
			this.Channel = channel;
			this.Texture = null;
			this.Scale = 1f;
			this.UOffset = 0f;
			this.VOffset = 0f;
			this.Repeat = false;
			this.RotationRads = 0f;
		}

		public void Import(DCustomEquipmentDecal decal, Texture2D tex = null)
		{
			this.Texture = tex;
			this.Scale = decal.Scale;
			this.UOffset = decal.Uoffset;
			this.VOffset = decal.Voffset;
			this.Repeat = decal.Repeat;
			this.RotationRads = decal.Rotation;
		}

		public DCustomEquipmentDecal Export()
		{
			return new DCustomEquipmentDecal
			{
				TextureName = ((this.Texture != null) ? this.Texture.name : null),
				Scale = this.Scale,
				Uoffset = this.UOffset,
				Voffset = this.VOffset,
				Repeat = this.Repeat,
				Rotation = this.RotationRads
			};
		}

		public override void Apply(Material mat)
		{
			mat.SetTexture(ShaderParams.DECAL_TEX[this.Channel], this.Texture);
			mat.SetFloat(ShaderParams.DECAL_SCALE[this.Channel], this.Scale);
			mat.SetFloat(ShaderParams.DECAL_U_OFFSET[this.Channel], this.UOffset);
			mat.SetFloat(ShaderParams.DECAL_V_OFFSET[this.Channel], this.VOffset);
			mat.SetFloat(ShaderParams.DECAL_REPEAT[this.Channel], this.Repeat ? 1f : 0f);
			mat.SetFloat(ShaderParams.DECAL_ROTATION_RADS[this.Channel], this.RotationRads);
		}

		public override List<Object> InternalReferences()
		{
			return new List<Object>
			{
				this.Texture
			};
		}

		public void ResetMaterial(Material mat)
		{
			DecalMaterialProperties.DefaultProperties[this.Channel].Apply(mat);
		}

		public override string ToString()
		{
			return string.Format("[DecalMaterial: Channel={0}, Texture={1}, Scale={2}, UOffset={3}, VOffset={4}, Repeat={5}, RotationRads={6}]", new object[]
			{
				this.Channel,
				this.Texture,
				this.Scale,
				this.UOffset,
				this.VOffset,
				this.Repeat,
				this.RotationRads
			});
		}
	}
}