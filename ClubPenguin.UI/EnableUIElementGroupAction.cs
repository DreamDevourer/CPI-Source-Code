// EnableUIElementGroupAction
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("UI")]
public class EnableUIElementGroupAction : FsmStateAction
{
	public string UIElementID;

	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(new UIDisablerEvents.EnableUIElementGroup(UIElementID));
		Finish();
	}
}
