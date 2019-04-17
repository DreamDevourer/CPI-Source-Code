// CustomEquipmentPart
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct CustomEquipmentPart
{
	public int slotIndex;

	public CustomEquipmentCustomization[] customizations;
}
