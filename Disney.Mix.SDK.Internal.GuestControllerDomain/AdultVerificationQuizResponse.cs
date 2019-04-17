// AdultVerificationQuizResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class AdultVerificationQuizResponse : GuestControllerWebCallResponse
{
	public AdultVerificationQuizData data
	{
		get;
		set;
	}
}
