// StructureInventoryData
using ClubPenguin;
using ClubPenguin.DecorationInventory;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections.Generic;

[Serializable]
internal class StructureInventoryData : ScopedData
{
	private Dictionary<int, int> structures;

	public Dictionary<int, int> Structures
	{
		get
		{
			return structures;
		}
		internal set
		{
			structures = new Dictionary<int, int>(value);
			if (this.OnStructuresChanged != null)
			{
				this.OnStructuresChanged(structures);
			}
		}
	}

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override Type monoBehaviourType => typeof(StructureInventoryDataMonoBehaviour);

	public event Action<Dictionary<int, int>> OnStructuresChanged;

	public void AddStructure(int defintionId, int count)
	{
		if (!structures.ContainsKey(defintionId))
		{
			structures[defintionId] = count;
		}
		else
		{
			Dictionary<int, int> dictionary;
			int key;
			(dictionary = structures)[key = defintionId] = dictionary[key] + count;
		}
		if (this.OnStructuresChanged != null)
		{
			this.OnStructuresChanged(structures);
		}
	}

	protected override void notifyWillBeDestroyed()
	{
	}
}
