using System;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public struct DCustomEquipmentPart
	{
		public int SlotIndex;

		public DCustomEquipmentDecal[] Decals;

		public override string ToString()
		{
			return string.Format("[DCustomEquipmentPart] SlotIndex: {0} #Decals: {1} Full hash: {2:x8} Resource Hash: {3:x8}", new object[]
			{
				this.SlotIndex,
				(this.Decals != null) ? this.Decals.Length.ToString() : "-",
				this.GetFullHash(),
				this.GetResourceHash()
			});
		}

		public int GetResourceHash()
		{
			StructHash sh = default(StructHash);
			if (this.Decals != null)
			{
				for (int i = 0; i < this.Decals.Length; i++)
				{
					sh.Combine<int>(this.Decals[i].GetResourceHash());
				}
			}
			return sh;
		}

		public int GetFullHash()
		{
			StructHash sh = default(StructHash);
			sh.Combine<int>(this.SlotIndex);
			if (this.Decals != null)
			{
				for (int i = 0; i < this.Decals.Length; i++)
				{
					sh.Combine<int>(this.Decals[i].GetFullHash());
				}
			}
			return sh;
		}

		public bool Validate()
		{
			bool flag = true;
			flag &= (this.SlotIndex >= 0);
			flag &= (this.Decals != null);
			int num = 0;
			while (flag && num < this.Decals.Length)
			{
				flag &= this.Decals[num].Validate();
				num++;
			}
			return flag;
		}
	}
}