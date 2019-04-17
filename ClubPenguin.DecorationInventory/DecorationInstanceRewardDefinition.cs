// DecorationInstanceRewardDefinition
using ClubPenguin.Core;
using ClubPenguin.DecorationInventory;
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class DecorationInstanceRewardDefinition : AbstractStaticGameDataRewardDefinition<DecorationDefinition>
{
	public DecorationDefinition Decoration;

	public int Count;

	public override IRewardable Reward => new DecorationInstanceReward(Decoration.Id, Count);

	protected override DecorationDefinition getField()
	{
		return Decoration;
	}
}
