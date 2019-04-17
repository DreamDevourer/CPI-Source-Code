// Compliance
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class Compliance
{
	public string defaultAgeBand
	{
		get;
		set;
	}

	public string defaultCountryCode
	{
		get;
		set;
	}

	public Dictionary<string, ConfigurationAgeBand> ageBands
	{
		get;
		set;
	}

	public List<string> embargoedCountries
	{
		get;
		set;
	}
}
