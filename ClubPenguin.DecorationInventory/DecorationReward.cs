// DecorationReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class DecorationReward : AbstractListReward<int>
{
	public List<int> Decorations => data;

	public override string RewardType => "decorationPurchaseRights";

	public DecorationReward()
	{
	}

	public DecorationReward(int value)
		: base(value)
	{
	}
}
