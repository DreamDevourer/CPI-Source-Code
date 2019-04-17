// DisableInfiniteAirAction
using ClubPenguin.World.Activities.Diving;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

public class DisableInfiniteAirAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(DivingEvents.DisableLocalInfiniteAir));
		Finish();
	}
}
