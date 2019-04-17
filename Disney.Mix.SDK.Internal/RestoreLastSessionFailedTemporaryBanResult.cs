// RestoreLastSessionFailedTemporaryBanResult
using Disney.Mix.SDK;

internal class RestoreLastSessionFailedTemporaryBanResult : IRestoreLastSessionFailedTemporaryBanResult, IRestoreLastSessionResult
{
	public bool Success
	{
		get;
		private set;
	}

	public ISession Session
	{
		get;
		private set;
	}

	public RestoreLastSessionFailedTemporaryBanResult()
	{
		Success = false;
		Session = null;
	}
}
