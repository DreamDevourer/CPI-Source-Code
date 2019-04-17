// ACatalogController
using ClubPenguin;
using ClubPenguin.Catalog;
using UnityEngine;

public abstract class ACatalogController : MonoBehaviour
{
	private ItemImageBuilder itemImageBuilderInstance;

	protected CatalogModel Model;

	protected ItemImageBuilder itemImageBuilder
	{
		get
		{
			if (itemImageBuilderInstance == null)
			{
				itemImageBuilderInstance = ItemImageBuilder.acquire();
			}
			return itemImageBuilderInstance;
		}
		set
		{
			itemImageBuilderInstance = value;
		}
	}

	public void SetModel(CatalogModel model)
	{
		Model = model;
	}

	public virtual void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	public virtual void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	protected virtual void OnDestroy()
	{
		if (itemImageBuilderInstance != null)
		{
			ItemImageBuilder.release();
			itemImageBuilderInstance = null;
		}
	}
}
