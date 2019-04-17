// TemplateSelectionController
using ClubPenguin.ClothingDesigner.ItemCustomizer;
using UnityEngine;

public class TemplateSelectionController : MonoBehaviour
{
	protected DItemCustomization itemModel;

	public void SetModel(DItemCustomization itemModel)
	{
		this.itemModel = itemModel;
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}
}
