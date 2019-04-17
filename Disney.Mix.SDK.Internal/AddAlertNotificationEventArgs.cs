// AddAlertNotificationEventArgs
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;

public class AddAlertNotificationEventArgs : AbstractAddAlertNotificationEventArgs
{
	public override AddAlertNotification Notification
	{
		get;
		protected set;
	}

	public AddAlertNotificationEventArgs(AddAlertNotification notification)
	{
		Notification = notification;
	}
}
