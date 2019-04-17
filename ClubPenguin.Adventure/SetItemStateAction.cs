// SetItemStateAction
using ClubPenguin.Adventure;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest (Advanced)")]
public class SetItemStateAction : FsmStateAction
{
	public string QuestItemName;

	public QuestItem.QuestItemState QuestState;

	public FsmInt ItemCount = 0;

	public override void OnEnter()
	{
		Service.Get<QuestService>().SetQuestItemState(base.Owner, base.Fsm.Name, QuestItemName, QuestState, ItemCount.Value);
		Finish();
	}
}
