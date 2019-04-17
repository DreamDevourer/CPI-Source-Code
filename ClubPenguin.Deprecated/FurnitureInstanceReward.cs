// FurnitureInstanceReward
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class FurnitureInstanceReward : AbstractListReward<string>
{
	public override string RewardType => "furnitureTemplates";

	public FurnitureInstanceReward()
	{
	}

	public FurnitureInstanceReward(string value)
		: base(value)
	{
	}
}
