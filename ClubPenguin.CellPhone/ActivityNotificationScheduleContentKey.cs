// ActivityNotificationScheduleContentKey
using ClubPenguin.CellPhone;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class ActivityNotificationScheduleContentKey : TypedAssetContentKey<ActivityNotificationSchedule>
{
	public ActivityNotificationScheduleContentKey()
	{
	}

	public ActivityNotificationScheduleContentKey(string key)
		: base(key)
	{
	}

	public ActivityNotificationScheduleContentKey(AssetContentKey key, params string[] args)
		: base(key, args)
	{
	}
}
