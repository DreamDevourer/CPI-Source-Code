// CatalogItemIcon
using ClubPenguin;
using ClubPenguin.Avatar;
using ClubPenguin.ClothingDesigner.Inventory;
using UnityEngine;
using UnityEngine.UI;

public class CatalogItemIcon : MonoBehaviour
{
	public static readonly Color ITEM_BACKGROUND_COLOR = new Color32(171, 119, 252, byte.MaxValue);

	public static readonly Color PENGUIN_COLOR = new Color32(127, 75, 211, byte.MaxValue);

	public GameObject LoadingSpinner;

	public RawImage ItemIcon;

	public InventoryIconModel<DCustomEquipment> IconData
	{
		get;
		private set;
	}

	private void Awake()
	{
		if (LoadingSpinner != null)
		{
			LoadingSpinner.SetActive(value: true);
		}
	}

	private void OnDisable()
	{
		if (LoadingSpinner != null)
		{
			LoadingSpinner.SetActive(value: true);
		}
	}

	public Texture GetIcon()
	{
		return ItemIcon.GetComponent<RawImage>().texture;
	}

	public void SetIcon(bool success, Texture2D icon, AbstractImageBuilder.CallbackToken callbackToken)
	{
		if (success && ItemIcon != null)
		{
			ItemIcon.texture = icon;
		}
	}

	public void SetupView(InventoryIconModel<DCustomEquipment> iconData, bool isPlayerMember)
	{
		IconData = iconData;
		if (!isPlayerMember)
		{
			setMemberViews(canEquip: false);
		}
		else
		{
			setMemberViews(canEquip: true);
		}
	}

	private void setMemberViews(bool canEquip)
	{
	}
}
