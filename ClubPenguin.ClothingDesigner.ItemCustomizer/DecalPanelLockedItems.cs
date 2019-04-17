// DecalPanelLockedItems
using ClubPenguin;
using ClubPenguin.Breadcrumbs;
using ClubPenguin.ClothingDesigner;
using ClubPenguin.ClothingDesigner.ItemCustomizer;
using ClubPenguin.Core;
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using Disney.MobileNetwork;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DecalPanelLockedItems : AbstractProgressionLockedItems<DecalDefinition>
{
	public PersistentBreadcrumbTypeDefinitionKey BreadcrumbType;

	private ScrollRect scrollRect;

	private bool scrollRectDefaultHorizontal;

	private bool scrollRectDefaultVertical;

	private EventChannel eventChannel;

	protected override void start()
	{
		eventChannel = new EventChannel(CustomizationContext.EventBus);
		setScrollBar();
	}

	protected override void createItem(DecalDefinition itemDefinition, GameObject item, ItemGroup.LockedState lockedState)
	{
		CustomizationButton component = item.GetComponent<CustomizationButton>();
		bool canDrag = lockedState == ItemGroup.LockedState.Unlocked;
		Texture2DContentKey fabricPath = EquipmentPathUtil.GetFabricPath(itemDefinition.AssetName);
		component.Init(fabricPath, BreadcrumbType, itemDefinition.Id, canDrag);
	}

	protected override DecalDefinition[] getRewards(RewardDefinition rewardDefinition)
	{
		return AbstractStaticGameDataRewardDefinition<DecalDefinition>.ToDefinitionArray(rewardDefinition.GetDefinitions<DecalRewardDefinition>());
	}

	protected override void modifyShownElement(int index, GameObject element)
	{
		LayoutElement componentInParent = element.GetComponentInParent<LayoutElement>();
		componentInParent.minWidth = 185f;
	}

	protected override DecalDefinition[] filterDefinitions(DecalDefinition[] definitions)
	{
		List<TagDefinition> filterTags = null;
		if (Service.Get<CatalogServiceProxy>().IsCatalogThemeActive())
		{
			CatalogThemeDefinition catalogTheme = Service.Get<CatalogServiceProxy>().GetCatalogTheme();
			if (catalogTheme != null)
			{
				filterTags = catalogTheme.DecalTags.ToList();
			}
		}
		List<DecalDefinition> list = new List<DecalDefinition>();
		if (filterTags != null && filterTags.Count > 0 && definitions != null)
		{
			for (int i = 0; i < definitions.Length; i++)
			{
				List<TagDefinition> list2 = definitions[i].Tags.ToList();
				int tagIndex;
				for (tagIndex = 0; tagIndex < filterTags.Count; tagIndex++)
				{
					if (list2.Exists((TagDefinition x) => x.Tag == filterTags[tagIndex].Tag) && !list.Contains(definitions[i]))
					{
						list.Add(definitions[i]);
						break;
					}
				}
			}
			return list.ToArray();
		}
		return definitions;
	}

	private void setScrollBar()
	{
		DecalScreenController componentInParent = GetComponentInParent<DecalScreenController>();
		if (componentInParent != null)
		{
			scrollRect = GetComponentInChildren<ScrollRect>();
			Scrollbar horizontalScrollbar = componentInParent.GetComponentsInChildren<Scrollbar>(includeInactive: true)[0];
			scrollRect.horizontalScrollbar = horizontalScrollbar;
			scrollRect.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			scrollRectDefaultHorizontal = scrollRect.horizontal;
			scrollRectDefaultVertical = scrollRect.vertical;
			eventChannel.AddListener<CustomizerUIEvents.EnableScrollRect>(onEnableScrollRect);
			eventChannel.AddListener<CustomizerUIEvents.DisableScrollRect>(onDisableScrollRect);
		}
	}

	private bool onEnableScrollRect(CustomizerUIEvents.EnableScrollRect evt)
	{
		scrollRect.horizontal = scrollRectDefaultHorizontal;
		scrollRect.vertical = scrollRectDefaultVertical;
		return false;
	}

	private bool onDisableScrollRect(CustomizerUIEvents.DisableScrollRect evt)
	{
		scrollRect.horizontal = false;
		scrollRect.vertical = false;
		return false;
	}

	private void OnDestroy()
	{
		eventChannel.RemoveAllListeners();
	}
}
