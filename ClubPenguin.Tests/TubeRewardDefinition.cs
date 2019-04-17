// TubeRewardDefinition
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using ClubPenguin.Tubes;
using System;

[Serializable]
public class TubeRewardDefinition : AbstractStaticGameDataRewardDefinition<TubeDefinition>
{
	public TubeDefinition Definition;

	public override IRewardable Reward => new TubeReward(Definition.Id);

	protected override TubeDefinition getField()
	{
		return Definition;
	}
}
