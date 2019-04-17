// RestoreLastSessionFailedInvalidRefreshTokenResult
using Disney.Mix.SDK;

internal class RestoreLastSessionFailedInvalidRefreshTokenResult : IRestoreLastSessionFailedInvalidRefreshTokenResult, IRestoreLastSessionResult
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

	public RestoreLastSessionFailedInvalidRefreshTokenResult()
	{
		Success = false;
		Session = null;
	}
}
