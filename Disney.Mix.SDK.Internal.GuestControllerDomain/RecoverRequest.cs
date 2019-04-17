// RecoverRequest
using Disney.Mix.SDK.Internal;

public class RecoverRequest : AbstractGuestControllerWebCallRequest
{
	public string lookupValue
	{
		get;
		set;
	}

	public string referenceId
	{
		get;
		set;
	}
}
