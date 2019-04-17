// ConfigurationAgeBand
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class ConfigurationAgeBand
{
	public string country
	{
		get;
		set;
	}

	public int minAge
	{
		get;
		set;
	}

	public int maxAge
	{
		get;
		set;
	}

	public LegalRequirements legalRequirements
	{
		get;
		set;
	}

	public Dictionary<string, FieldRequirements> UPDATE
	{
		get;
		set;
	}

	public Dictionary<string, FieldRequirements> CREATE
	{
		get;
		set;
	}
}
