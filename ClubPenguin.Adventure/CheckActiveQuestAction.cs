// CheckActiveQuestAction
using ClubPenguin.Adventure;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class CheckActiveQuestAction : FsmStateAction
{
	public FsmEvent IsOnQuestEvent;

	public FsmEvent IsNotOnQuestEvent;

	public override void OnEnter()
	{
		if (Service.Get<QuestService>().ActiveQuest != null)
		{
			base.Fsm.Event(IsOnQuestEvent);
		}
		else
		{
			base.Fsm.Event(IsNotOnQuestEvent);
		}
	}
}
