// DisableAllUIElementsAction
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("UI")]
public class DisableAllUIElementsAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(UIDisablerEvents.DisableAllUIElements));
		Finish();
	}
}
