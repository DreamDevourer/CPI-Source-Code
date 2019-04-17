using System;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public struct DCustomEquipment
	{
		public long Id;

		public int DefinitionId;

		public string Name;

		public DCustomEquipmentPart[] Parts;

		public long DateTimeCreated;

		public override string ToString()
		{
			return string.Format("[DCustomEquipment] DefinitionId: {0} Name: {1} Id: {2} #Parts: {3} Full hash: {4:x8}, Resource hash: {5:x8}", new object[]
			{
				this.DefinitionId,
				this.Name,
				this.Id,
				(this.Parts != null) ? this.Parts.Length.ToString() : "-",
				this.GetFullHash(),
				this.GetResourceHash()
			});
		}

		public int GetResourceHash()
		{
			StructHash sh = default(StructHash);
			sh.Combine<string>(this.Name ?? string.Empty);
			if (this.Parts != null)
			{
				for (int i = 0; i < this.Parts.Length; i++)
				{
					sh.Combine<int>(this.Parts[i].GetResourceHash());
				}
			}
			return sh;
		}

		public int GetFullHash()
		{
			StructHash sh = default(StructHash);
			sh.Combine<long>(this.Id);
			sh.Combine<int>(this.DefinitionId);
			sh.Combine<string>(this.Name ?? string.Empty);
			if (this.Parts != null)
			{
				for (int i = 0; i < this.Parts.Length; i++)
				{
					sh.Combine<int>(this.Parts[i].GetFullHash());
				}
			}
			return sh;
		}

		public bool Validate()
		{
			bool flag = true;
			flag &= (this.Id != 0L);
			flag &= (this.DefinitionId != 0);
			flag &= !string.IsNullOrEmpty(this.Name);
			flag &= (this.Parts != null);
			int num = 0;
			while (flag && num < this.Parts.Length)
			{
				flag &= this.Parts[num].Validate();
				num++;
			}
			return flag;
		}
	}
}