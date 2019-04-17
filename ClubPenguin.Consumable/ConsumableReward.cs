// ConsumableReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class ConsumableReward : AbstractListReward<int>
{
	public List<int> Consumable => data;

	public override string RewardType => "partySupplies";

	public ConsumableReward()
	{
	}

	public ConsumableReward(int value)
		: base(value)
	{
	}
}
