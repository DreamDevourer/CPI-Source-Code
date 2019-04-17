// MarketplacePopupController
using ClubPenguin.UI;
using Disney.MobileNetwork;
using UnityEngine;

public class MarketplacePopupController : MonoBehaviour
{
	public Transform PopupContainer;

	public GameObject ItemPopupPrefab;

	public GameObject AdPopupPrefab;

	private MarketplaceItemPopup itemPopup;

	private MarketplaceAdPopup adPopup;

	public MarketplaceItemPopup ItemPopup => itemPopup;

	public MarketplaceAdPopup AdPopup => adPopup;

	private void Awake()
	{
		GameObject gameObject = Object.Instantiate(ItemPopupPrefab);
		gameObject.transform.SetParent(PopupContainer);
		itemPopup = gameObject.GetComponent<MarketplaceItemPopup>();
		gameObject.SetActive(value: false);
		GameObject gameObject2 = Object.Instantiate(AdPopupPrefab);
		gameObject2.transform.SetParent(PopupContainer);
		adPopup = gameObject2.GetComponent<MarketplaceAdPopup>();
		gameObject2.SetActive(value: false);
	}

	private void OnDestroy()
	{
		Service.Get<BackButtonController>().Remove(onBackButtonClicked);
	}

	private void onBackButtonClicked()
	{
		HidePopup();
	}

	public void HidePopup()
	{
		itemPopup.gameObject.SetActive(value: false);
		adPopup.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
	}

	public void ShowItemPopup(MarketplaceScreenController.MarketplaceItemData itemData, Sprite itemIcon, MarketplaceItemLockStates lockStates)
	{
		Service.Get<BackButtonController>().Add(onBackButtonClicked);
		if (adPopup.gameObject.activeSelf)
		{
			adPopup.gameObject.SetActive(value: false);
		}
		base.gameObject.SetActive(value: true);
		itemPopup.gameObject.SetActive(value: true);
		itemPopup.GetComponent<MarketplaceItemPopup>().SetData(itemData, itemIcon, lockStates);
	}

	public void ShowAdPopup(MarketplaceScreenController.MarketplaceItemData itemData, string adDescription, Sprite itemIcon, Sprite backgroundImage)
	{
		Service.Get<BackButtonController>().Add(onBackButtonClicked);
		if (itemPopup.gameObject.activeSelf)
		{
			itemPopup.gameObject.SetActive(value: false);
		}
		base.gameObject.SetActive(value: true);
		adPopup.gameObject.SetActive(value: true);
		adPopup.GetComponent<MarketplaceAdPopup>().SetData(itemData, adDescription, itemIcon, backgroundImage);
	}

	public void OnCloseButtonPressed()
	{
		HidePopup();
	}
}
