// AcceptAndStartQuestAction
using ClubPenguin.Actions;
using ClubPenguin.Adventure;
using Disney.MobileNetwork;

public class AcceptAndStartQuestAction : Action
{
	public string QuestName;

	protected override void OnEnable()
	{
		Quest quest = Service.Get<QuestService>().GetQuest(QuestName);
		quest.Activate();
	}

	protected override void Update()
	{
		Completed();
	}

	protected override void CopyTo(Action _dest)
	{
		AcceptAndStartQuestAction acceptAndStartQuestAction = _dest as AcceptAndStartQuestAction;
		acceptAndStartQuestAction.QuestName = QuestName;
		base.CopyTo(_dest);
	}
}
