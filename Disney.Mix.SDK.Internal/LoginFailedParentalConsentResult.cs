// LoginFailedParentalConsentResult
using Disney.Mix.SDK;

internal class LoginFailedParentalConsentResult : ILoginFailedParentalConsentResult, ILoginResult
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

	public LoginFailedParentalConsentResult()
	{
		Success = false;
		Session = null;
	}
}
