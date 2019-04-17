// MascotXPRewardDefinition
using ClubPenguin.Adventure;
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using ClubPenguin.NPC;
using System;

[Serializable]
public class MascotXPRewardDefinition : AbstractStaticGameDataRewardDefinition<MascotDefinition>
{
	public MascotDefinition Mascot;

	public int XP;

	public override IRewardable Reward => new MascotXPReward(Mascot.name, XP);

	protected override MascotDefinition getField()
	{
		return Mascot;
	}
}
