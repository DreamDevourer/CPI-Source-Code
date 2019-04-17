// ConsumableInstanceReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class ConsumableInstanceReward : AbstractDictionaryReward<string, int>
{
	public Dictionary<string, int> Consumables => data;

	public override string RewardType => "consumables";

	public ConsumableInstanceReward()
	{
	}

	public ConsumableInstanceReward(string key, int value)
		: base(key, value)
	{
	}

	protected override int combineValues(int val1, int val2)
	{
		return val1 + val2;
	}
}
