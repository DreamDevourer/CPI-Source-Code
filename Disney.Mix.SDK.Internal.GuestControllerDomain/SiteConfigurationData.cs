// SiteConfigurationData
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class SiteConfigurationData
{
	public Compliance compliance
	{
		get;
		set;
	}

	public Dictionary<string, ConfigurationMarketingAgeBand> marketing
	{
		get;
		set;
	}

	public Dictionary<string, LegalGroup> legal
	{
		get;
		set;
	}
}
