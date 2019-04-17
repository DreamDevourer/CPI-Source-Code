// EquipPropItemAction
using ClubPenguin.Actions;
using ClubPenguin.Props;
using Disney.MobileNetwork;

public class EquipPropItemAction : Action
{
	public string PropItemPrefabPath;

	protected override void CopyTo(Action _destWarper)
	{
		EquipPropItemAction equipPropItemAction = _destWarper as EquipPropItemAction;
		equipPropItemAction.PropItemPrefabPath = PropItemPrefabPath;
		base.CopyTo(_destWarper);
	}

	protected override void Update()
	{
		if (!string.IsNullOrEmpty(PropItemPrefabPath) && GetTarget().CompareTag("Player"))
		{
			Service.Get<PropService>().LocalPlayerRetrieveProp(PropItemPrefabPath);
		}
		Completed();
	}
}
