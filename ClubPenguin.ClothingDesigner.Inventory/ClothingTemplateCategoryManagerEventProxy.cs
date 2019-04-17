// ClothingTemplateCategoryManagerEventProxy
using ClubPenguin.ClothingDesigner;
using ClubPenguin.ClothingDesigner.Inventory;
using ClubPenguin.ClothingDesigner.ItemCustomizer;

public class ClothingTemplateCategoryManagerEventProxy : CategoryManagerEventProxy
{
	public override void OnAllButton()
	{
		CustomizationContext.EventBus.DispatchEvent(default(ClothingDesignerUIEvents.ShowAllTemplates));
	}

	public override void OnButtonPressed(string category)
	{
		CustomizationContext.EventBus.DispatchEvent(new ClothingDesignerUIEvents.CategoryChange(category));
	}
}
