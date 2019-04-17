// DisableUIElementGroupAction
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("UI")]
public class DisableUIElementGroupAction : FsmStateAction
{
	public string UIElementID;

	public bool HideElements;

	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(new UIDisablerEvents.DisableUIElementGroup(UIElementID, HideElements));
		Finish();
	}
}
