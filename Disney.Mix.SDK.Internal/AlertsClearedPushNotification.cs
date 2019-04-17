// AlertsClearedPushNotification
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class AlertsClearedPushNotification : AbstractPushNotification, IAlertsClearedPushNotification, IPushNotification
{
	public AlertsClearedPushNotification(bool notificationsAvailable)
		: base(notificationsAvailable)
	{
	}
}
