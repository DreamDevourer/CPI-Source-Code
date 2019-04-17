// CustomEquipmentCollection
using ClubPenguin.Net.Domain;
using ClubPenguin.Net.Offline;
using System.Collections.Generic;

public struct CustomEquipmentCollection : IOfflineData
{
	public List<CustomEquipment> Equipment;

	public void Init()
	{
		Equipment = new List<CustomEquipment>();
	}
}
