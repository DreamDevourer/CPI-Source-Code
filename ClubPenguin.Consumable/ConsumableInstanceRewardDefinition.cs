// ConsumableInstanceRewardDefinition
using ClubPenguin.Consumable;
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using ClubPenguin.Props;
using System;

[Serializable]
public class ConsumableInstanceRewardDefinition : AbstractStaticGameDataRewardDefinition<PropDefinition>
{
	public PropDefinition Consumable;

	public int Count;

	public override IRewardable Reward => new ConsumableInstanceReward(Consumable.NameOnServer, Count);

	protected override PropDefinition getField()
	{
		return Consumable;
	}
}
