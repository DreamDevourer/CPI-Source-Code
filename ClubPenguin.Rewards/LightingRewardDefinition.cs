// LightingRewardDefinition
using ClubPenguin.Core;
using ClubPenguin.DecorationInventory;
using ClubPenguin.Net.Domain;
using ClubPenguin.Rewards;
using System;

[Serializable]
public class LightingRewardDefinition : AbstractStaticGameDataRewardDefinition<LightingDefinition>
{
	public LightingDefinition Definition;

	public override IRewardable Reward => new LightingReward(Definition.Id);

	protected override LightingDefinition getField()
	{
		return Definition;
	}
}
