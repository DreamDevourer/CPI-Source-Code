// SetPlayerOutOfWorldAction
using ClubPenguin.Adventure;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class SetPlayerOutOfWorldAction : FsmStateAction
{
	public bool IsOutOfWorld;

	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(new QuestEvents.SetPlayerOutOfWorld(IsOutOfWorld));
		Finish();
	}
}
