// LotReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class LotReward : AbstractListReward<string>
{
	public List<string> Lots => data;

	public override string RewardType => "lots";

	public LotReward()
	{
	}

	public LotReward(string value)
		: base(value)
	{
	}
}
