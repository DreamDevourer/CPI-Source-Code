// RestoreLastSessionFailedAccountLockedOutResult
using Disney.Mix.SDK;

internal class RestoreLastSessionFailedAccountLockedOutResult : IRestoreLastSessionFailedAccountLockedOutResult, IRestoreLastSessionResult
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

	public RestoreLastSessionFailedAccountLockedOutResult()
	{
		Success = false;
		Session = null;
	}
}
