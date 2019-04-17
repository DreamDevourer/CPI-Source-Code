// DispatchPlayerMovedEventAction
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

public class DispatchPlayerMovedEventAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(PlaymakerExternalEvents.FTUEPlayerMoved));
		Finish();
	}
}
