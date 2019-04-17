// IInventoryService
using ClubPenguin.Net;
using ClubPenguin.Net.Domain;

public interface IInventoryService : INetworkService
{
	void CreateCustomEquipment(CustomEquipment equipmentRequest);

	void GetEquipmentInventory();

	void DeleteCustomEquipment(long equipmentId);
}
