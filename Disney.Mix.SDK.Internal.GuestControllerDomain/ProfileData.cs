// ProfileData
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class ProfileData : DisplayNameData
{
	public Profile profile
	{
		get;
		set;
	}

	public List<MarketingItem> marketing
	{
		get;
		set;
	}
}
