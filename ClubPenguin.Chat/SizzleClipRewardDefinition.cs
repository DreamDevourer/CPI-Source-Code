// SizzleClipRewardDefinition
using ClubPenguin.Chat;
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using ClubPenguin.UI;
using System;

[Serializable]
public class SizzleClipRewardDefinition : AbstractStaticGameDataRewardDefinition<SizzleClipDefinition>
{
	public SizzleClipDefinition Definition;

	public override IRewardable Reward => new SizzleClipReward(Definition.Id);

	protected override SizzleClipDefinition getField()
	{
		return Definition;
	}
}
