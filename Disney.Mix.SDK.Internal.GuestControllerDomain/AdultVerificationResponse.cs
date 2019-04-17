// AdultVerificationResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class AdultVerificationResponse : GuestControllerWebCallResponse
{
	public AdultVerificationData data
	{
		get;
		set;
	}
}
