// RegisterQuestSubFSMAction
using ClubPenguin.Adventure;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class RegisterQuestSubFSMAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<EventDispatcher>().DispatchEvent(new QuestEvents.RegisterQuestSubFsm(base.Fsm));
		Finish();
	}
}
