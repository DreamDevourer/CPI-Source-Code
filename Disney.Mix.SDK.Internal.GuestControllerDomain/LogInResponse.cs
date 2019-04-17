// LogInResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class LogInResponse : GuestControllerWebCallResponse
{
	public LogInData data
	{
		get;
		set;
	}
}
