// IReuseExistingGuestControllerLoginResult
using Disney.Mix.SDK;

public interface IReuseExistingGuestControllerLoginResult
{
	bool Success
	{
		get;
	}

	ISession Session
	{
		get;
	}
}
