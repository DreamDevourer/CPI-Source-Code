using System;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public struct DCustomEquipmentDecal
	{
		public EquipmentDecalType Type;

		public string TextureName;

		public int DefinitionId;

		public int Index;

		public float Scale;

		public float Uoffset;

		public float Voffset;

		public float Rotation;

		public bool Repeat;

		public override string ToString()
		{
			return string.Format("[DCustomEquipmentDecal] DefinitionId: {0} Name: {1} Type: {2} Full hash: {3:x8} Resource hash: {4:x8}", new object[]
			{
				this.DefinitionId,
				this.TextureName,
				this.Type,
				this.GetFullHash(),
				this.GetResourceHash()
			});
		}

		public int GetResourceHash()
		{
			StructHash sh = default(StructHash);
			sh.Combine<string>(this.TextureName ?? string.Empty);
			return sh;
		}

		public int GetFullHash()
		{
			StructHash sh = default(StructHash);
			sh.Combine<EquipmentDecalType>(this.Type);
			sh.Combine<string>(this.TextureName ?? string.Empty);
			sh.Combine<int>(this.DefinitionId);
			sh.Combine<int>(this.Index);
			sh.Combine<float>(this.Scale);
			sh.Combine<float>(this.Uoffset);
			sh.Combine<float>(this.Voffset);
			sh.Combine<float>(this.Rotation);
			sh.Combine<bool>(this.Repeat);
			return sh;
		}

		public bool Validate()
		{
			bool flag = true;
			flag &= !string.IsNullOrEmpty(this.TextureName);
			return flag & this.DefinitionId != 0;
		}
	}
}