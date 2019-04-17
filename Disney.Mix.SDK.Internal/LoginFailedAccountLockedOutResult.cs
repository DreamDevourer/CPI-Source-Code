// LoginFailedAccountLockedOutResult
using Disney.Mix.SDK;

internal class LoginFailedAccountLockedOutResult : ILoginFailedAccountLockedOutResult, ILoginResult
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

	public LoginFailedAccountLockedOutResult()
	{
		Success = false;
		Session = null;
	}
}
