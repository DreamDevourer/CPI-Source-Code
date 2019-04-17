// AbstractAddAlertNotificationEventArgs
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public abstract class AbstractAddAlertNotificationEventArgs : EventArgs
{
	public abstract AddAlertNotification Notification
	{
		get;
		protected set;
	}
}
