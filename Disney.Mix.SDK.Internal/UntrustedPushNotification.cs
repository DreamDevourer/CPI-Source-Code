// UntrustedPushNotification
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class UntrustedPushNotification : AbstractPushNotification, IUntrustedPushNotification, IPushNotification
{
	public UntrustedPushNotification(bool notificationsAvailable)
		: base(notificationsAvailable)
	{
	}
}
