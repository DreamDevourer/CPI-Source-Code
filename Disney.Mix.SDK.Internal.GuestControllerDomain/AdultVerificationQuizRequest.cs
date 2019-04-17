// AdultVerificationQuizRequest
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class AdultVerificationQuizRequest : AbstractGuestControllerWebCallRequest
{
	public string applicationId
	{
		get;
		set;
	}

	public List<AdultVerificationQuizAnswer> answers
	{
		get;
		set;
	}
}
