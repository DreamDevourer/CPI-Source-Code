// DecorationRewardDefinition
using ClubPenguin.Core;
using ClubPenguin.DecorationInventory;
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class DecorationRewardDefinition : AbstractStaticGameDataRewardDefinition<DecorationDefinition>
{
	public DecorationDefinition Definition;

	public override IRewardable Reward => new DecorationReward(Definition.Id);

	protected override DecorationDefinition getField()
	{
		return Definition;
	}
}
