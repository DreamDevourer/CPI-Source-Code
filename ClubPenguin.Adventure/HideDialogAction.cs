// HideDialogAction
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest (Advanced)")]
public class HideDialogAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(CinematicSpeechEvents.HideAllSpeechEvent));
		Finish();
	}
}
