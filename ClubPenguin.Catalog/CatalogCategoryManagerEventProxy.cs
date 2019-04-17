// CatalogCategoryManagerEventProxy
using ClubPenguin.Catalog;
using ClubPenguin.ClothingDesigner.Inventory;

public class CatalogCategoryManagerEventProxy : CategoryManagerEventProxy
{
	public override void OnAllButton()
	{
		CatalogContext.EventBus.DispatchEvent(default(CatalogUIEvents.SubNavAllButtonClickedEvent));
	}

	public override void OnButtonPressed(string category)
	{
		CatalogContext.EventBus.DispatchEvent(new CatalogUIEvents.SubNavCategoryButtonClickedEvent(category));
	}
}
