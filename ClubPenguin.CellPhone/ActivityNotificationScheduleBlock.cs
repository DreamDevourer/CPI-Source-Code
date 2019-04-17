// ActivityNotificationScheduleBlock
using ClubPenguin.CellPhone;
using System;

[Serializable]
public struct ActivityNotificationScheduleBlock
{
	public int TriggerTime;

	public CellPhoneActivityDefinition[] Notifications;
}
