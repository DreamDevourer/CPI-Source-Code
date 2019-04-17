// CreateEquipmentResponse
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class CreateEquipmentResponse : CPResponse
{
	public long equipmentId;

	public PlayerAssets assets;
}
