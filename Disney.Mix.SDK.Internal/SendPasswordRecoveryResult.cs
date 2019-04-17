// SendPasswordRecoveryResult
using Disney.Mix.SDK;

internal class SendPasswordRecoveryResult : ISendPasswordRecoveryResult
{
	public bool Success
	{
		get;
		private set;
	}

	public SendPasswordRecoveryResult(bool success)
	{
		Success = success;
	}
}
