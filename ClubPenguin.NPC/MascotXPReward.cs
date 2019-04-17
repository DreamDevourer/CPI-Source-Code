// MascotXPReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class MascotXPReward : AbstractDictionaryReward<string, int>
{
	public Dictionary<string, int> XP => data;

	public override string RewardType => "mascotXP";

	public MascotXPReward()
	{
	}

	public MascotXPReward(string key, int value)
		: base(key, value)
	{
	}

	protected override int combineValues(int val1, int val2)
	{
		return val1 + val2;
	}
}
