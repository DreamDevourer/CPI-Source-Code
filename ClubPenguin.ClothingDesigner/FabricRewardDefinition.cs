// FabricRewardDefinition
using ClubPenguin;
using ClubPenguin.ClothingDesigner;
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class FabricRewardDefinition : AbstractStaticGameDataRewardDefinition<FabricDefinition>
{
	public FabricDefinition Definition;

	public override IRewardable Reward => new FabricReward(Definition.Id);

	protected override FabricDefinition getField()
	{
		return Definition;
	}
}
