// LoginFailedProfileDisabledResult
using Disney.Mix.SDK;

internal class LoginFailedProfileDisabledResult : ILoginFailedProfileDisabledResult, ILoginResult
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

	public LoginFailedProfileDisabledResult()
	{
		Success = false;
		Session = null;
	}
}
