// DisableAllPushNotificationsResult
using Disney.Mix.SDK;

public class DisableAllPushNotificationsResult : IDisableAllPushNotificationsResult
{
	public bool Success
	{
		get;
		private set;
	}

	public DisableAllPushNotificationsResult(bool success)
	{
		Success = success;
	}
}
