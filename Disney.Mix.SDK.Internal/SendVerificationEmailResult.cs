// SendVerificationEmailResult
using Disney.Mix.SDK;

public class SendVerificationEmailResult : ISendVerificationEmailResult
{
	public bool Success
	{
		get;
		private set;
	}

	public SendVerificationEmailResult(bool success)
	{
		Success = success;
	}
}
