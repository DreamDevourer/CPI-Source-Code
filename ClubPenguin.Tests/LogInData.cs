// LogInData
using ClubPenguin.Tests;
using System.Collections.Generic;

public class LogInData
{
	public string etag
	{
		get;
		set;
	}

	public Profile profile
	{
		get;
		set;
	}

	public DisplayName displayName
	{
		get;
		set;
	}

	public Token token
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
