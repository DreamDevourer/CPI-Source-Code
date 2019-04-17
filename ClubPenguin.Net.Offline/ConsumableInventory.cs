// ConsumableInventory
using ClubPenguin.Net.Domain;
using ClubPenguin.Net.Offline;
using System.Collections.Generic;

public struct ConsumableInventory : IOfflineData
{
	public Dictionary<string, InventoryItemStock> Inventory;

	public void Init()
	{
		Inventory = new Dictionary<string, InventoryItemStock>();
	}
}
