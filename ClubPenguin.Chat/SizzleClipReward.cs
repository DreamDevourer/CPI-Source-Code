// SizzleClipReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class SizzleClipReward : AbstractListReward<int>
{
	public List<int> SizzleClips => data;

	public override string RewardType => "sizzleClips";

	public SizzleClipReward()
	{
	}

	public SizzleClipReward(int value)
		: base(value)
	{
	}
}
