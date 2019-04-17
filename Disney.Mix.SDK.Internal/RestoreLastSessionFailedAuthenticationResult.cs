// RestoreLastSessionFailedAuthenticationResult
using Disney.Mix.SDK;

internal class RestoreLastSessionFailedAuthenticationResult : IRestoreLastSessionFailedAuthenticationResult, IRestoreLastSessionResult
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

	public RestoreLastSessionFailedAuthenticationResult()
	{
		Success = false;
		Session = null;
	}
}
