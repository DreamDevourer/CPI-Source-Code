// AbstractNotificationsPolledEventArgs
using System;

public abstract class AbstractNotificationsPolledEventArgs : EventArgs
{
	public abstract long LastNotificationTimestamp
	{
		get;
		protected set;
	}
}
