// UpdateProfileRequest
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class UpdateProfileRequest : AbstractGuestControllerWebCallRequest
{
	public string etag
	{
		get;
		set;
	}

	public Dictionary<string, string> profile
	{
		get;
		set;
	}

	public List<Disney.Mix.SDK.Internal.GuestControllerDomain.MarketingItem> marketing
	{
		get;
		set;
	}

	public RegisterDisplayName displayName
	{
		get;
		set;
	}

	public List<string> legalAssertions
	{
		get;
		set;
	}
}
