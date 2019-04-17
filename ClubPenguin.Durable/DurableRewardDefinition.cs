// DurableRewardDefinition
using ClubPenguin.Core;
using ClubPenguin.Durable;
using ClubPenguin.Net.Domain;
using ClubPenguin.Props;
using System;

[Serializable]
public class DurableRewardDefinition : AbstractStaticGameDataRewardDefinition<PropDefinition>
{
	public PropDefinition Definition;

	public override IRewardable Reward => new DurableReward(Definition.Id);

	protected override PropDefinition getField()
	{
		return Definition;
	}
}
