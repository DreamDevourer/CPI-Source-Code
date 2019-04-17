// ConfigurationMarketingAgeBand
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class ConfigurationMarketingAgeBand
{
	public Dictionary<string, ConfigurationMarketingItem> CREATE
	{
		get;
		set;
	}

	public Dictionary<string, ConfigurationMarketingItem> UPDATE
	{
		get;
		set;
	}

	public Dictionary<string, ConfigurationMarketingItem> PARTIAL
	{
		get;
		set;
	}
}
