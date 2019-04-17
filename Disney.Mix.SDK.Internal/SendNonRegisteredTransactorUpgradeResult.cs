// SendNonRegisteredTransactorUpgradeResult
using Disney.Mix.SDK;

internal class SendNonRegisteredTransactorUpgradeResult : ISendNonRegisteredTransactorUpgradeResult
{
	public bool Success
	{
		get;
		private set;
	}

	public SendNonRegisteredTransactorUpgradeResult(bool success)
	{
		Success = success;
	}
}
