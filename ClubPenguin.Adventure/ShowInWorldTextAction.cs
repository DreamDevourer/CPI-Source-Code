// ShowInWorldTextAction
using ClubPenguin.World;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class ShowInWorldTextAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(InWorldUIEvents.EnableInWorldText));
		Finish();
	}
}
