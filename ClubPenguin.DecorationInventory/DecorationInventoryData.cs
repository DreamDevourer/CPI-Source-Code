// DecorationInventoryData
using ClubPenguin;
using ClubPenguin.DecorationInventory;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections.Generic;

[Serializable]
internal class DecorationInventoryData : ScopedData
{
	private Dictionary<int, int> decorations;

	public Dictionary<int, int> Decorations
	{
		get
		{
			return decorations;
		}
		internal set
		{
			decorations = new Dictionary<int, int>(value);
			if (this.OnDecorationsChanged != null)
			{
				this.OnDecorationsChanged(decorations);
			}
		}
	}

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override Type monoBehaviourType => typeof(DecorationInventoryDataMonoBehaviour);

	public event Action<Dictionary<int, int>> OnDecorationsChanged;

	public void AddDecoration(int defintionId, int count)
	{
		if (!decorations.ContainsKey(defintionId))
		{
			decorations[defintionId] = count;
		}
		else
		{
			Dictionary<int, int> dictionary;
			int key;
			(dictionary = decorations)[key = defintionId] = dictionary[key] + count;
		}
		if (this.OnDecorationsChanged != null)
		{
			this.OnDecorationsChanged(decorations);
		}
	}

	protected override void notifyWillBeDestroyed()
	{
	}
}
