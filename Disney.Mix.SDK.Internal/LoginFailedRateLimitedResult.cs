// LoginFailedRateLimitedResult
using Disney.Mix.SDK;

internal class LoginFailedRateLimitedResult : ILoginFailedRateLimitedResult, ILoginResult
{
	public bool Success => false;

	public ISession Session => null;
}
