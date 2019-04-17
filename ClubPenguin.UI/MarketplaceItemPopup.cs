// MarketplaceItemPopup
using ClubPenguin.UI;
using DevonLocalization.Core;
using Disney.MobileNetwork;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MarketplaceItemPopup : MonoBehaviour
{
	private const string LEVEL_TOKEN = "Marketplace.Level.Text";

	private const string MEMBER_TOKEN = "Marketplace.Member.Text";

	private const string MEMBER_DESC_TOKEN = "Marketplace.MemberDesc.Text";

	private const string STOCK_TOKEN = "Marketplace.Stock.Text";

	private const string STOCK_DESC_TOKEN = "Marketplace.StockDesc.Text";

	private const string LEVEL_DESC_TOKEN = "Marketplace.LevelDesc.Text";

	public Image ItemIcon;

	public GameObject LockIcon;

	public GameObject LearnMoreButton;

	public Text HeaderText;

	public Text DescriptionText;

	public Text ListHeaderText;

	public Text ListLevelText;

	public Text ListBuyCountText;

	public GameObject ListLevelItem;

	public GameObject ListBuyCountItem;

	private Localizer localizer;

	public event Action LearnMoreButtonPressed;

	public void SetData(MarketplaceScreenController.MarketplaceItemData itemData, Sprite itemIcon, MarketplaceItemLockStates lockStates)
	{
		localizer = Service.Get<Localizer>();
		ListBuyCountItem.SetActive(value: false);
		ItemIcon.sprite = itemIcon;
		ListHeaderText.text = localizer.GetTokenTranslation(itemData.PropDefn.Name);
		ListLevelText.text = itemData.UnlockLevel.ToString();
		if (lockStates.IsMemberLocked)
		{
			LockIcon.SetActive(value: true);
			LearnMoreButton.SetActive(value: true);
			HeaderText.text = localizer.GetTokenTranslation("Marketplace.Member.Text");
			DescriptionText.text = localizer.GetTokenTranslation("Marketplace.MemberDesc.Text");
		}
		else if (lockStates.IsOutOfStock)
		{
			ListBuyCountItem.SetActive(value: false);
			HeaderText.text = localizer.GetTokenTranslation("Marketplace.Stock.Text");
			DescriptionText.text = localizer.GetTokenTranslation("Marketplace.StockDesc.Text");
		}
		else if (lockStates.IsLevelLocked)
		{
			string str = itemData.UnlockLevel.ToString();
			HeaderText.text = localizer.GetTokenTranslation("Marketplace.Level.Text") + str;
			DescriptionText.text = localizer.GetTokenTranslation("Marketplace.LevelDesc.Text");
		}
		if (!lockStates.IsLevelLocked && itemData.UnlockLevel == 0)
		{
			ListLevelItem.SetActive(value: false);
		}
	}

	private void OnDisable()
	{
		LockIcon.SetActive(value: false);
		LearnMoreButton.SetActive(value: false);
		ListBuyCountItem.SetActive(value: true);
		ListLevelItem.SetActive(value: true);
	}

	public void OnLearnMorePressed()
	{
		if (this.LearnMoreButtonPressed != null)
		{
			this.LearnMoreButtonPressed();
		}
	}
}
