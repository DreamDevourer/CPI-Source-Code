// SendMassPushNotificationResult
using Disney.Mix.SDK;

public class SendMassPushNotificationResult : ISendMassPushNotificationResult
{
	public bool Success
	{
		get;
		private set;
	}

	public SendMassPushNotificationResult(bool success)
	{
		Success = success;
	}
}
