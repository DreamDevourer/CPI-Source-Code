// RestoreLastSessionFailedInvalidOrExpiredTokenResult
using Disney.Mix.SDK;

internal class RestoreLastSessionFailedInvalidOrExpiredTokenResult : IRestoreLastSessionFailedInvalidOrExpiredTokenResult, IRestoreLastSessionResult
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

	public RestoreLastSessionFailedInvalidOrExpiredTokenResult()
	{
		Success = false;
		Session = null;
	}
}
