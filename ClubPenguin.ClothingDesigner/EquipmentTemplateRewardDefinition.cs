// EquipmentTemplateRewardDefinition
using ClubPenguin;
using ClubPenguin.ClothingDesigner;
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class EquipmentTemplateRewardDefinition : AbstractStaticGameDataRewardDefinition<TemplateDefinition>
{
	public TemplateDefinition Definition;

	public override IRewardable Reward => new EquipmentTemplateReward(Definition.Id);

	protected override TemplateDefinition getField()
	{
		return Definition;
	}
}
