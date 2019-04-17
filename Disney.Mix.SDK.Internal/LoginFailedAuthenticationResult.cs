// LoginFailedAuthenticationResult
using Disney.Mix.SDK;

public class LoginFailedAuthenticationResult : ILoginFailedAuthenticationResult, ILoginResult
{
	public bool Success => false;

	public ISession Session => null;
}
