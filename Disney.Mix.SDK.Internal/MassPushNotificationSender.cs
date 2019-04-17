// MassPushNotificationSender
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using System;

public static class MassPushNotificationSender
{
	public static void SendMassPushNotification(AbstractLogger logger, IMixWebCallFactory mixWebCallFactory, Action<bool> callback)
	{
		logger.Critical("Not Implemented : SendMassPushNotification");
		callback(obj: false);
	}
}
