// DurableReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class DurableReward : AbstractListReward<int>
{
	public List<int> Durables => data;

	public override string RewardType => "durables";

	public DurableReward()
	{
	}

	public DurableReward(int value)
		: base(value)
	{
	}
}
