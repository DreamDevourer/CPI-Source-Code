// ClearAlertNotificationEventArgs
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;

public class ClearAlertNotificationEventArgs : AbstractClearAlertNotificationEventArgs
{
	public override ClearAlertNotification Notification
	{
		get;
		protected set;
	}

	public ClearAlertNotificationEventArgs(ClearAlertNotification notification)
	{
		Notification = notification;
	}
}
