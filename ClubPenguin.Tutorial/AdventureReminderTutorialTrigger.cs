// AdventureReminderTutorialTrigger
using ClubPenguin.Adventure;
using ClubPenguin.Tutorial;
using Disney.MobileNetwork;
using UnityEngine;

public class AdventureReminderTutorialTrigger : MonoBehaviour
{
	public string MascotName;

	public TutorialDefinitionKey TutorialDefinition;

	private void Start()
	{
		if (!Service.Get<TutorialManager>().IsTutorialAvailable(TutorialDefinition.Id))
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && Service.Get<QuestService>().ActiveQuest == null && !AdventureReminderTutorial.IsReminderTutorialShown(MascotName) && Service.Get<TutorialManager>().TryStartTutorial(TutorialDefinition.Id))
		{
			AdventureReminderTutorial.SetReminderTutorialShown(MascotName);
		}
	}
}
