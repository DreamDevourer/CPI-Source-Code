// TubeReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class TubeReward : AbstractListReward<int>
{
	public List<int> Tubes => data;

	public override string RewardType => "tubes";

	public TubeReward()
	{
	}

	public TubeReward(int value)
		: base(value)
	{
	}
}
