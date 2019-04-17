// HideScheduledFog
using ClubPenguin.SpecialEvents;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class HideScheduledFog : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(ScheduledCoreEvents.HideFog));
		Finish();
	}
}
