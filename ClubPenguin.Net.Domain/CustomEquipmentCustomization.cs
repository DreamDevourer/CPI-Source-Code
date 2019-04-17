// CustomEquipmentCustomization
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct CustomEquipmentCustomization
{
	public EquipmentCustomizationType type;

	public int definitionId;

	public int index;

	public float scale;

	public float uoffset;

	public float voffset;

	public float rotation;

	public bool repeat;
}
