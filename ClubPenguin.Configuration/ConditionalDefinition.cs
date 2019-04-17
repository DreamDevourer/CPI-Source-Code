// ConditionalDefinition
using ClubPenguin.Configuration;
using ClubPenguin.Core.StaticGameData;
using System;

public class ConditionalDefinition : StaticGameDataDefinition
{
	public bool SendAnalytics = true;

	public virtual ConditionalProperty GenerateProperty()
	{
		throw new InvalidOperationException("GenerateProperty must be overriden in sub class");
	}
}
