// SendMultipleAccountsResolutionResult
using Disney.Mix.SDK;

internal class SendMultipleAccountsResolutionResult : ISendMultipleAccountsResolutionResult
{
	public bool Success
	{
		get;
		private set;
	}

	public SendMultipleAccountsResolutionResult(bool success)
	{
		Success = success;
	}
}
