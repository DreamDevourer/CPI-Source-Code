// UpdateBaitCounterAction
using ClubPenguin.MiniGames.Fishing;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Fishing")]
public class UpdateBaitCounterAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(FishingEvents.UpdateFishingBaitUI));
		Finish();
	}
}
