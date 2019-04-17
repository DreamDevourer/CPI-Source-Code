// LightingReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class LightingReward : AbstractListReward<int>
{
	public List<int> Lighting => data;

	public override string RewardType => "lighting";

	public LightingReward()
	{
	}

	public LightingReward(int value)
		: base(value)
	{
	}
}
