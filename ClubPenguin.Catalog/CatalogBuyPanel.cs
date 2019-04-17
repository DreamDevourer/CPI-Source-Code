// CatalogBuyPanel
using ClubPenguin.Catalog;
using UnityEngine;
using UnityEngine.UI;

public class CatalogBuyPanel : MonoBehaviour
{
	public CatalogShopBuyPanelState State;

	public Text ItemNameText;

	public Text CreatorNameText;

	public Text PurchaseCountText;

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void SetText(string itemName, string creatorName, string purchasedCount)
	{
		if (ItemNameText != null)
		{
			ItemNameText.text = itemName;
		}
		if (CreatorNameText != null)
		{
			CreatorNameText.text = creatorName;
		}
		if (PurchaseCountText != null)
		{
			PurchaseCountText.text = purchasedCount;
		}
	}
}
