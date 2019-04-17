// ClothingDesignerHeaderController
using ClubPenguin.Catalog;
using ClubPenguin.ClothingDesigner;
using ClubPenguin.ClothingDesigner.ItemCustomizer;
using DevonLocalization.Core;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

public class ClothingDesignerHeaderController : MonoBehaviour
{
	private Image challengeHeaderImage;

	private Text challengeHeaderText;

	private void Awake()
	{
		challengeHeaderImage = GetComponentInChildren<Image>();
		challengeHeaderText = GetComponentInChildren<Text>(includeInactive: true);
		ClothingDesignerContext.EventBus.AddListener<ClothingDesignerUIEvents.ChangeStateInventory>(onTemplateState);
		CatalogContext.EventBus.AddListener<CatalogUIEvents.AcceptChallengeClickedEvent>(onAcceptChallengeClicked);
		CustomizationContext.EventBus.AddListener<CustomizerUIEvents.StartPurchaseMoment>(onStartPurchaseMoment);
		challengeHeaderImage.gameObject.SetActive(value: false);
	}

	private bool onStartPurchaseMoment(CustomizerUIEvents.StartPurchaseMoment evt)
	{
		challengeHeaderImage.gameObject.SetActive(value: false);
		return false;
	}

	private bool onTemplateState(ClothingDesignerUIEvents.ChangeStateInventory evt)
	{
		challengeHeaderImage.gameObject.SetActive(value: false);
		return false;
	}

	private bool onAcceptChallengeClicked(CatalogUIEvents.AcceptChallengeClickedEvent evt)
	{
		challengeHeaderImage.gameObject.SetActive(value: true);
		if (evt.Theme != null && evt.Theme.Title != null)
		{
			if (evt.Theme.Title != null)
			{
				challengeHeaderText.text = Service.Get<Localizer>().GetTokenTranslation(evt.Theme.Title);
			}
			challengeHeaderImage.color = evt.ThemeColors[1];
		}
		return false;
	}

	private void OnDestroy()
	{
		ClothingDesignerContext.EventBus.RemoveListener<ClothingDesignerUIEvents.ChangeStateInventory>(onTemplateState);
		CatalogContext.EventBus.RemoveListener<CatalogUIEvents.AcceptChallengeClickedEvent>(onAcceptChallengeClicked);
		CustomizationContext.EventBus.RemoveListener<CustomizerUIEvents.StartPurchaseMoment>(onStartPurchaseMoment);
	}
}
