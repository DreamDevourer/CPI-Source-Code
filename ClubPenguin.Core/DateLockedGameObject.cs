// DateLockedGameObject
using ClubPenguin;
using ClubPenguin.Core;
using Disney.MobileNetwork;
using UnityEngine;

public class DateLockedGameObject : MonoBehaviour
{
	public ScheduledEventDateDefinition UnlockedDate;

	private void Awake()
	{
		if (Service.Get<ContentSchedulerService>().IsBeforeScheduleEventDates(UnlockedDate))
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
