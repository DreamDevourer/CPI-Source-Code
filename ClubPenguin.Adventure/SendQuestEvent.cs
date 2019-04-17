// SendQuestEvent
using ClubPenguin.Actions;
using ClubPenguin.Adventure;
using Disney.MobileNetwork;

public class SendQuestEvent : Action
{
	public string QuestEvent;

	protected override void OnEnable()
	{
		if (Owner.CompareTag("Player"))
		{
			QuestService questService = Service.Get<QuestService>();
			questService.SendEvent(QuestEvent);
		}
	}

	protected override void CopyTo(Action _dest)
	{
		SendQuestEvent sendQuestEvent = _dest as SendQuestEvent;
		sendQuestEvent.QuestEvent = QuestEvent;
		base.CopyTo(_dest);
	}

	protected override void Update()
	{
		Completed();
	}
}
