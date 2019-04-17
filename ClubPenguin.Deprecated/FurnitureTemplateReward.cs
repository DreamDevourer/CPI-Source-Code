// FurnitureTemplateReward
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class FurnitureTemplateReward : AbstractListReward<object>
{
	public override string RewardType => "furnitureInstances";

	public FurnitureTemplateReward()
	{
	}

	public FurnitureTemplateReward(object value)
		: base(value)
	{
	}
}
