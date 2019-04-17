// FabricReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class FabricReward : AbstractListReward<int>
{
	public List<int> Fabrics => data;

	public override string RewardType => "fabrics";

	public FabricReward()
	{
	}

	public FabricReward(int value)
		: base(value)
	{
	}
}
