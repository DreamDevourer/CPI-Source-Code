// PurchaseDisneyStoreItemResponse
using ClubPenguin.Net.Domain;
using ClubPenguin.Net.Domain.Decoration;

public class PurchaseDisneyStoreItemResponse : CPResponse
{
	public PlayerAssets assets;

	public SignedResponse<ConsumableInventory> inventory;

	public SignedResponse<DecorationInventory> decorationInventory;
}
