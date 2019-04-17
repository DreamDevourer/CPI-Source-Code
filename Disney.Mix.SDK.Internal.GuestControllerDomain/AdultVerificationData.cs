// AdultVerificationData
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class AdultVerificationData
{
	public string applicationId
	{
		get;
		set;
	}

	public string refId
	{
		get;
		set;
	}

	public bool verified
	{
		get;
		set;
	}

	public bool maxAttempts
	{
		get;
		set;
	}

	public List<AdultVerificationQuestion> questions
	{
		get;
		set;
	}
}
