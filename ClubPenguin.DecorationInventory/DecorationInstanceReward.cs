// DecorationInstanceReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class DecorationInstanceReward : AbstractDictionaryReward<int, int>
{
	public Dictionary<int, int> Decorations => data;

	public override string RewardType => "decorationInstances";

	public DecorationInstanceReward()
	{
	}

	public DecorationInstanceReward(int key, int value)
		: base(key, value)
	{
	}

	protected override int combineValues(int val1, int val2)
	{
		return val1 + val2;
	}
}
