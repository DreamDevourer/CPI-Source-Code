// PlayerOutfitDetails
using ClubPenguin.Net.Domain;
using ClubPenguin.Net.Offline;
using System.Collections.Generic;

public struct PlayerOutfitDetails : IOfflineData
{
	public List<CustomEquipment> Parts;

	public void Init()
	{
		Parts = new List<CustomEquipment>();
	}
}
