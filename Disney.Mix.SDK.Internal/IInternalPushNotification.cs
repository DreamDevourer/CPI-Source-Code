// IInternalPushNotification
using Disney.Mix.SDK;

public interface IInternalPushNotification : IPushNotification
{
	bool NotificationsAvailable
	{
		get;
	}
}
