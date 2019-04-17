// HideAllTutorialPopupsAction
using ClubPenguin.TutorialUI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Tutorial")]
public class HideAllTutorialPopupsAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(TutorialUIEvents.HideAllTutorialPopups));
		Finish();
	}
}
