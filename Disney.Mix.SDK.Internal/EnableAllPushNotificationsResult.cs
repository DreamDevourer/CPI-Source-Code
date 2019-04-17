// EnableAllPushNotificationsResult
using Disney.Mix.SDK;

public class EnableAllPushNotificationsResult : IEnableAllPushNotificationsResult
{
	public bool Success
	{
		get;
		private set;
	}

	public EnableAllPushNotificationsResult(bool success)
	{
		Success = success;
	}
}
