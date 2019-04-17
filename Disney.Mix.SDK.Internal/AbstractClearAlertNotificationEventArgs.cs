// AbstractClearAlertNotificationEventArgs
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public abstract class AbstractClearAlertNotificationEventArgs : EventArgs
{
	public abstract ClearAlertNotification Notification
	{
		get;
		protected set;
	}
}
