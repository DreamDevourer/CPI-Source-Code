// HideTutorialPopupAction
using ClubPenguin.TutorialUI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Tutorial")]
public class HideTutorialPopupAction : FsmStateAction
{
	public FsmString PopupID;

	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(new TutorialUIEvents.HideTutorialPopup(PopupID.Value));
		Finish();
	}
}
