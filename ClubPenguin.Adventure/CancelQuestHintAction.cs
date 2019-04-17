// CancelQuestHintAction
using ClubPenguin.Adventure;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class CancelQuestHintAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(QuestEvents.CancelQuestHint));
		Finish();
	}
}
