// LoginResult
using Disney.Mix.SDK;

public class LoginResult : ILoginResult
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

	public LoginResult(bool success, ISession session)
	{
		Success = success;
		Session = session;
	}
}
