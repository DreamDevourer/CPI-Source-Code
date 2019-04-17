// PlayerOutfitDetails
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct PlayerOutfitDetails
{
	public long? sessionId;

	public CustomEquipment[] parts;
}
