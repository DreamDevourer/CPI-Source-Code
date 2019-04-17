// ISavedOutfitService
using ClubPenguin.Net;
using ClubPenguin.Net.Domain;

public interface ISavedOutfitService : INetworkService
{
	void SaveSavedOutfit(SavedOutfit savedOutfit);

	void GetSavedOutfits();

	void DeleteSavedOutfit(int outfitSlot);
}
