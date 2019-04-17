// EquipmentIcon
using ClubPenguin;
using ClubPenguin.Avatar;
using ClubPenguin.Breadcrumbs;
using ClubPenguin.ClothingDesigner;
using ClubPenguin.ClothingDesigner.Inventory;
using ClubPenguin.UI;
using Disney.MobileNetwork;
using Fabric;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentIcon : MonoBehaviour
{
	private const string SHOW_ANIM_PARAM = "Show";

	private const string HIDE_ANIM_PARAM = "Hide";

	public GameObject ItemContentGameObject;

	public GameObject CreateButtonGameObject;

	public GameObject CatalogButtonGameObject;

	public GameObject Item;

	public GameObject LoadingSpinner;

	public RawImage ItemIcon;

	public Animator SelectedAnimator;

	public NotificationBreadcrumb Breadcrumb;

	public TutorialBreadcrumb TutorialBreadcrumb;

	public PersistentBreadcrumbTypeDefinitionKey BreadcrumbType;

	[SerializeField]
	private GameObject memberLockImage;

	[SerializeField]
	private TintSelector glossTintSelector;

	private NotificationBreadcrumbController breadcrumbController;

	private MaterialSelector[] materialSelectors;

	public long EquipmentId
	{
		get;
		private set;
	}

	public bool IsEquippable
	{
		get;
		private set;
	}

	public InventoryIconModel<DCustomEquipment> IconData
	{
		get;
		private set;
	}

	private void Awake()
	{
		Item.SetActive(value: false);
		LoadingSpinner.SetActive(value: true);
		breadcrumbController = Service.Get<NotificationBreadcrumbController>();
	}

	private void OnEnable()
	{
		InventoryContext.EventBus.AddListener<InventoryModelEvents.SelectEquipment>(onSelectItem);
		InventoryContext.EventBus.AddListener<InventoryModelEvents.DeselectEquipment>(onDeselectItem);
	}

	private void OnDisable()
	{
		if (Item != null)
		{
			Item.SetActive(value: false);
		}
		if (LoadingSpinner != null)
		{
			LoadingSpinner.SetActive(value: true);
		}
		InventoryContext.EventBus.RemoveListener<InventoryModelEvents.SelectEquipment>(onSelectItem);
		InventoryContext.EventBus.RemoveListener<InventoryModelEvents.DeselectEquipment>(onDeselectItem);
		if (CreateButtonGameObject != null && CreateButtonGameObject.activeSelf)
		{
			if (ItemContentGameObject != null)
			{
				ItemContentGameObject.SetActive(value: true);
			}
			CreateButtonGameObject.SetActive(value: false);
		}
	}

	public void SetupView(InventoryIconModel<DCustomEquipment> iconData, bool isPlayerMember)
	{
		IconData = iconData;
		EquipmentId = IconData.Id;
		activateSelected(iconData.IsEquipped);
		if (!isPlayerMember)
		{
			setMemberViews(canEquip: false);
		}
		else
		{
			setMemberViews(canEquip: true);
		}
		setBreadcrumbId();
	}

	private void setMemberViews(bool canEquip)
	{
		int index = (!canEquip) ? 1 : 0;
		memberLockImage.SetActive(!canEquip);
		if (materialSelectors == null)
		{
			materialSelectors = GetComponentsInChildren<MaterialSelector>(includeInactive: true);
		}
		for (int i = 0; i < materialSelectors.Length; i++)
		{
			if (materialSelectors[i] != null)
			{
				materialSelectors[i].SelectMaterial(index);
			}
		}
		glossTintSelector.SelectColor(index);
		IsEquippable = canEquip;
	}

	private void setBreadcrumbId()
	{
		Breadcrumb.SetBreadcrumbId(BreadcrumbType, EquipmentId.ToString());
		if (TutorialBreadcrumb != null)
		{
			TutorialBreadcrumb.SetBreadcrumbId($"Equipment_{EquipmentId}");
		}
	}

	public void SetIcon(bool success, Texture2D icon, AbstractImageBuilder.CallbackToken callbackToken)
	{
		if (callbackToken.Id == EquipmentId && success)
		{
			if (LoadingSpinner != null)
			{
				LoadingSpinner.SetActive(value: false);
			}
			if (ItemIcon != null)
			{
				ItemIcon.texture = icon;
				Item.SetActive(value: true);
			}
		}
	}

	public void OnIconButton()
	{
		if (IsEquippable)
		{
			onIconSelected();
		}
		else
		{
			ClothingDesignerContext.EventBus.DispatchEvent(new ClothingDesignerUIEvents.ShowMemberFlow("customizer_item"));
		}
	}

	public void SetupCreateButton()
	{
		ItemContentGameObject.SetActive(value: false);
		CreateButtonGameObject.SetActive(value: true);
		CatalogButtonGameObject.SetActive(value: false);
	}

	public void CreateButtonPressed()
	{
		EventManager.Instance.PostEvent("SFX/UI/ClothingDesigner/ButtonCreate", EventAction.PlaySound);
		ClothingDesignerContext.EventBus.DispatchEvent(default(ClothingDesignerUIEvents.ChangeStateCustomizer));
	}

	public void SetupEquipmentButton()
	{
		ItemContentGameObject.SetActive(value: true);
		CreateButtonGameObject.SetActive(value: false);
		CatalogButtonGameObject.SetActive(value: false);
	}

	public void SetupCatalogButton()
	{
		ItemContentGameObject.SetActive(value: false);
		CreateButtonGameObject.SetActive(value: false);
		CatalogButtonGameObject.SetActive(value: true);
	}

	public void CatalogButtonPressed()
	{
		EventManager.Instance.PostEvent("SFX/UI/ClothingDesigner/ButtonCreate", EventAction.PlaySound);
		ClothingDesignerContext.EventBus.DispatchEvent(default(ClothingDesignerUIEvents.ShowCatalog));
	}

	public Texture GetIcon()
	{
		return ItemIcon.GetComponent<RawImage>().texture;
	}

	private void onIconSelected()
	{
		InventoryContext.EventBus.DispatchEvent(new InventoryUIEvents.EquipEquipment(EquipmentId));
	}

	private bool onSelectItem(InventoryModelEvents.SelectEquipment evt)
	{
		if (evt.Id == EquipmentId)
		{
			activateSelected(isActivated: true);
			breadcrumbController.RemovePersistentBreadcrumb(BreadcrumbType, EquipmentId.ToString());
		}
		return false;
	}

	private bool onDeselectItem(InventoryModelEvents.DeselectEquipment evt)
	{
		if (evt.Id == EquipmentId)
		{
			activateSelected(isActivated: false);
		}
		return false;
	}

	private void activateSelected(bool isActivated)
	{
		if (isActivated)
		{
			SelectedAnimator.ResetTrigger("Hide");
			SelectedAnimator.SetTrigger("Show");
		}
		else
		{
			SelectedAnimator.ResetTrigger("Show");
			SelectedAnimator.SetTrigger("Hide");
		}
	}
}
