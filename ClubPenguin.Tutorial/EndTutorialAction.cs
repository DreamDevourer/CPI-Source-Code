// EndTutorialAction
using ClubPenguin.Tutorial;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Tutorial")]
public class EndTutorialAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<TutorialManager>().EndTutorial();
		Finish();
	}
}
