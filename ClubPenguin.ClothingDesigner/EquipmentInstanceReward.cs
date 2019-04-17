// EquipmentInstanceReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class EquipmentInstanceReward : AbstractListReward<CustomEquipment>
{
	public List<CustomEquipment> EquipmentInstances => data;

	public override string RewardType => "equipmentInstances";

	public EquipmentInstanceReward()
	{
	}

	public EquipmentInstanceReward(CustomEquipment value)
		: base(value)
	{
	}
}
