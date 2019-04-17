// CatalogBuyPanelPurchase
using ClubPenguin.Catalog;
using UnityEngine.UI;

public class CatalogBuyPanelPurchase : CatalogBuyPanel
{
	public Button ItemCostButton;

	public Button NotEnoughCoinsButton;

	public Text ItemCostText;

	public CatalogNotEnoughCoinsToolTip ToolTip;

	public void SetPurchaseButtonInteractableState(bool isInteractable)
	{
		ItemCostButton.interactable = isInteractable;
	}

	public void SetVisibleButton(bool hasEnoughCoins)
	{
		if (hasEnoughCoins)
		{
			ItemCostButton.gameObject.SetActive(value: true);
			NotEnoughCoinsButton.gameObject.SetActive(value: false);
		}
		else
		{
			ItemCostButton.gameObject.SetActive(value: false);
			NotEnoughCoinsButton.gameObject.SetActive(value: true);
		}
	}

	public void ShowNotEnoughCoinsToolTip()
	{
		ToolTip.Show();
	}

	private void OnDisable()
	{
		ToolTip.Hide();
	}
}
