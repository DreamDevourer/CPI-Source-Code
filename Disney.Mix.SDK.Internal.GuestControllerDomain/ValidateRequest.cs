// ValidateRequest
using Disney.Mix.SDK.Internal;

public class ValidateRequest : AbstractGuestControllerWebCallRequest
{
	public string email
	{
		get;
		set;
	}

	public string displayName
	{
		get;
		set;
	}

	public string username
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
