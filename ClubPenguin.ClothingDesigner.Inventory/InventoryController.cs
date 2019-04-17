// InventoryController
using ClubPenguin.Breadcrumbs;
using ClubPenguin.ClothingDesigner.Inventory;
using ClubPenguin.Core;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;

public class InventoryController
{
	private InventoryEquipmentModel model;

	private StaticBreadcrumbDefinitionKey breadcrumb;

	public InventoryController(StaticBreadcrumbDefinitionKey breadcrumb)
	{
		this.breadcrumb = breadcrumb;
	}

	public void Init(EquipmentListController equipmentListController)
	{
		setupModel();
		InventoryContext.EventBus.DispatchEvent(new InventoryUIEvents.ModelCreated(model));
		equipmentListController.gameObject.SetActive(value: true);
		equipmentListController.Init(model);
		Service.Get<NotificationBreadcrumbController>().ResetBreadcrumbs(breadcrumb);
	}

	private void setupModel()
	{
		model = new InventoryEquipmentModel();
		if (Service.Get<CPDataEntityCollection>().TryGetComponent(Service.Get<CPDataEntityCollection>().LocalPlayerHandle, out InventoryData component))
		{
			model.SetInventory(component);
		}
		else
		{
			Log.LogError(this, "Unable to locate InventoryData object. This object should already exist as it is created in the home controller.");
		}
	}
}
