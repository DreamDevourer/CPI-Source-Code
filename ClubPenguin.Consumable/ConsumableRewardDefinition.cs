// ConsumableRewardDefinition
using ClubPenguin.Consumable;
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using ClubPenguin.Props;
using System;

[Serializable]
public class ConsumableRewardDefinition : AbstractStaticGameDataRewardDefinition<PropDefinition>
{
	public PropDefinition Definition;

	public override IRewardable Reward => new ConsumableReward(Definition.Id);

	protected override PropDefinition getField()
	{
		return Definition;
	}
}
