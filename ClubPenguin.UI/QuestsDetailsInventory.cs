// QuestsDetailsInventory
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class QuestsDetailsInventory : MonoBehaviour
{
	public GameObject AdventureInventoryScreenPrefab;

	private readonly PrefabContentKey inventoryScreenKey = new PrefabContentKey("ScreenQuestsDetailsPrefabs/AdventureInventoryScreen");

	private GameObject adventureInventoryScreen;

	private void Start()
	{
		loadScreen();
	}

	private void loadScreen()
	{
		Content.LoadAsync(onScreenLoaded, inventoryScreenKey);
	}

	private void onScreenLoaded(string path, GameObject screenPrefab)
	{
		adventureInventoryScreen = Object.Instantiate(screenPrefab);
		Service.Get<EventDispatcher>().DispatchEvent(new PopupEvents.ShowPopup(adventureInventoryScreen, destroyPopupOnBackPressed: false, scaleToFit: true, "Accessibility.Popup.Title.QuestInventory"));
	}

	private void OnDestroy()
	{
		if (adventureInventoryScreen != null)
		{
			Object.Destroy(adventureInventoryScreen);
		}
	}
}
