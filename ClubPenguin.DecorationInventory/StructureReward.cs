// StructureReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class StructureReward : AbstractListReward<int>
{
	public List<int> Structures => data;

	public override string RewardType => "structurePurchaseRights";

	public StructureReward()
	{
	}

	public StructureReward(int value)
		: base(value)
	{
	}
}
