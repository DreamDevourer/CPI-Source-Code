// LogInRequest
using Disney.Mix.SDK.Internal;

public class LogInRequest : AbstractGuestControllerWebCallRequest
{
	public string loginValue
	{
		get;
		set;
	}

	public string password
	{
		get;
		set;
	}
}
