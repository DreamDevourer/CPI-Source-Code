// ExchangeTutorialTrigger
using ClubPenguin.Adventure;
using ClubPenguin.Tutorial;
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Runtime.InteropServices;
using UnityEngine;

public class ExchangeTutorialTrigger : MonoBehaviour
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ExchangeTutorialTriggered
	{
	}

	public TutorialDefinitionKey TutorialDefinition;

	private void Start()
	{
		if (!Service.Get<TutorialManager>().IsTutorialAvailable(TutorialDefinition.Id))
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Player") || Service.Get<QuestService>().ActiveQuest != null)
		{
			return;
		}
		GameObject gameObject = GameObject.FindWithTag("UIHud");
		if (gameObject != null)
		{
			CollectiblesHud componentInChildren = gameObject.GetComponentInChildren<CollectiblesHud>(includeInactive: true);
			if (componentInChildren != null && componentInChildren.ShouldShowCollectibleTutorial && Service.Get<TutorialManager>().TryStartTutorial(TutorialDefinition.Id))
			{
				Service.Get<EventDispatcher>().DispatchEvent(default(ExchangeTutorialTriggered));
				componentInChildren.ShouldShowCollectibleTutorial = false;
			}
		}
	}
}
