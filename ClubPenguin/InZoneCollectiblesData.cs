// InZoneCollectiblesData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections.Generic;

[Serializable]
public class InZoneCollectiblesData : ScopedData
{
	private Dictionary<string, long> collectedRewards = null;

	public Dictionary<string, long> CollectedRewards
	{
		set
		{
			collectedRewards = value;
		}
	}

	protected override string scopeID => CPDataScopes.Zone.ToString();

	protected override Type monoBehaviourType => typeof(InZoneCollectiblesDataMonoBehaviour);

	public bool HasBeenCollected(string path)
	{
		return collectedRewards.ContainsKey(path);
	}

	public long GetRespawnTime(string path)
	{
		if (!HasBeenCollected(path))
		{
			return 0L;
		}
		return collectedRewards[path];
	}

	protected override void notifyWillBeDestroyed()
	{
	}
}
