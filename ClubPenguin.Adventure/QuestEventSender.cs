// QuestEventSender
using ClubPenguin.Adventure;
using Disney.MobileNetwork;
using UnityEngine;

public class QuestEventSender : MonoBehaviour
{
	public void SendQuestEvent(string questEvent)
	{
		Service.Get<QuestService>().SendEvent(questEvent);
	}
}
