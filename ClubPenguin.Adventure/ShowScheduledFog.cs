// ShowScheduledFog
using ClubPenguin.SpecialEvents;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class ShowScheduledFog : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(ScheduledCoreEvents.ShowFog));
		Finish();
	}
}
