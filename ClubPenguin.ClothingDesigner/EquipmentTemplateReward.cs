// EquipmentTemplateReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class EquipmentTemplateReward : AbstractListReward<int>
{
	public List<int> EquipmentTemplates => data;

	public override string RewardType => "equipmentTemplates";

	public EquipmentTemplateReward()
	{
	}

	public EquipmentTemplateReward(int value)
		: base(value)
	{
	}
}
