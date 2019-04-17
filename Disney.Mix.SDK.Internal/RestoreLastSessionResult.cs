// RestoreLastSessionResult
using Disney.Mix.SDK;

public class RestoreLastSessionResult : IRestoreLastSessionResult
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

	public RestoreLastSessionResult(bool success, ISession session)
	{
		Success = success;
		Session = session;
	}
}
