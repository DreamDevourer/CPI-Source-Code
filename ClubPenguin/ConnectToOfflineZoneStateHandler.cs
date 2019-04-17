// ConnectToOfflineZoneStateHandler
using ClubPenguin;
using Disney.Kelowna.Common.SEDFSM;
using Disney.MobileNetwork;

public class ConnectToOfflineZoneStateHandler : AbstractStateHandler
{
	protected override void OnEnter()
	{
		Service.Get<ZoneTransitionService>().ConnectToZone(Service.Get<GameStateController>().GetZoneToLoad());
		rootStateMachine.SendEvent("zoneconnectingevent");
	}
}
