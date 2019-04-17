// UnfriendedPushNotification
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class UnfriendedPushNotification : AbstractPushNotification, IUnfriendedPushNotification, IPushNotification
{
	public UnfriendedPushNotification(bool notificationsAvailable)
		: base(notificationsAvailable)
	{
	}
}
