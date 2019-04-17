// DecalReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class DecalReward : AbstractListReward<int>
{
	public List<int> Decals => data;

	public override string RewardType => "decals";

	public DecalReward()
	{
	}

	public DecalReward(int value)
		: base(value)
	{
	}
}
