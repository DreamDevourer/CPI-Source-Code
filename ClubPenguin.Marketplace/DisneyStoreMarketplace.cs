// DisneyStoreMarketplace
using ClubPenguin;
using ClubPenguin.Marketplace;
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using UnityEngine;

public class DisneyStoreMarketplace : MonoBehaviour
{
	public PrefabContentKey prefabContentKey = new PrefabContentKey("Prefabs/DisneyStoreMarketplaceScreen");

	public MarketplaceDefinition definition;

	private GameObject marketplaceObject;

	private bool isLoadingPrefab = false;

	public void ActivateMarketplace(GameObject sender)
	{
		if (sender.CompareTag("Player") && !isLoadingPrefab && Object.FindObjectOfType<MarketplaceScreenController>() == null)
		{
			isLoadingPrefab = true;
			SceneRefs.FullScreenPopupManager.CreatePopup(prefabContentKey, "Accessibility.Popup.Title.Marketplace", useCameraSpace: false, onPrefabCreated);
		}
	}

	private void onPrefabCreated(PrefabContentKey key, GameObject marketplaceObject)
	{
		MarketplaceScreenController component = marketplaceObject.GetComponent<MarketplaceScreenController>();
		if (component != null)
		{
			component.Init(definition);
		}
		isLoadingPrefab = false;
	}
}
