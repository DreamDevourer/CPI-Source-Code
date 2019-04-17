// ClearWaypointAction
using ClubPenguin;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class ClearWaypointAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<ZonePathing>().ClearWaypoint();
		Finish();
	}
}
