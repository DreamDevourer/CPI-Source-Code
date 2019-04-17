// MusicTrackRewardDefinition
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using ClubPenguin.Rewards;
using System;

[Serializable]
public class MusicTrackRewardDefinition : AbstractStaticGameDataRewardDefinition<MusicTrackDefinition>
{
	public MusicTrackDefinition Definition;

	public override IRewardable Reward => new MusicTrackReward(Definition.Id);

	protected override MusicTrackDefinition getField()
	{
		return Definition;
	}
}
