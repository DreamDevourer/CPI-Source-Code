// CollectibleReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class CollectibleReward : AbstractDictionaryReward<string, int>
{
	public Dictionary<string, int> Collectibles => data;

	public override string RewardType => "collectibleCurrency";

	public CollectibleReward()
	{
	}

	public CollectibleReward(string key, int value)
		: base(key, value)
	{
	}

	protected override int combineValues(int val1, int val2)
	{
		return val1 + val2;
	}
}
