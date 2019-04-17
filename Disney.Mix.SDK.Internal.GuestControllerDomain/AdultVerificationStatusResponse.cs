// AdultVerificationStatusResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class AdultVerificationStatusResponse : GuestControllerWebCallResponse
{
	public AdultVerificationStatusData data
	{
		get;
		set;
	}
}
