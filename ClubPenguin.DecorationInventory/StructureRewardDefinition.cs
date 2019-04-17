// StructureRewardDefinition
using ClubPenguin.Core;
using ClubPenguin.DecorationInventory;
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class StructureRewardDefinition : AbstractStaticGameDataRewardDefinition<StructureDefinition>
{
	public StructureDefinition Definition;

	public override IRewardable Reward => new StructureReward(Definition.Id);

	protected override StructureDefinition getField()
	{
		return Definition;
	}
}
