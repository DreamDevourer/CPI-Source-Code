// LotRewardDefinition
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using ClubPenguin.Rewards;
using System;

[Serializable]
public class LotRewardDefinition : AbstractStaticGameDataRewardDefinition<LotDefinition>
{
	public LotDefinition Definition;

	public override IRewardable Reward => new LotReward(Definition.LotName);

	protected override LotDefinition getField()
	{
		return Definition;
	}
}
