// ShowBreadcrumbAction
using ClubPenguin.Breadcrumbs;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("UI")]
public class ShowBreadcrumbAction : FsmStateAction
{
	public string BreadcrumbId;

	public int BreadcrumbCount = 1;

	public override void OnEnter()
	{
		Service.Get<NotificationBreadcrumbController>().AddBreadcrumb(BreadcrumbId, BreadcrumbCount);
		Finish();
	}
}
