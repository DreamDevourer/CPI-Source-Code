// CustomEquipment
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct CustomEquipment
{
	public long equipmentId;

	public long dateTimeCreated;

	public int definitionId;

	public CustomEquipmentPart[] parts;
}
