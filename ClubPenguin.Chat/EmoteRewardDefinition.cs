// EmoteRewardDefinition
using ClubPenguin.Chat;
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class EmoteRewardDefinition : AbstractStaticGameDataRewardDefinition<EmoteDefinition>
{
	public EmoteDefinition Definition;

	public override IRewardable Reward => new EmoteReward(Definition.Id);

	protected override EmoteDefinition getField()
	{
		return Definition;
	}
}
