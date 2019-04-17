// ActionButtonRequestRuleDefinition
using ClubPenguin;
using ClubPenguin.Core.StaticGameData;
using System;

[Serializable]
public class ActionButtonRequestRuleDefinition : StaticGameDataDefinition
{
	public enum Proximity
	{
		UsesProximity,
		IgnoresProximity
	}

	[StaticGameDataDefinitionId]
	public string Category;

	public int Priority;

	public Proximity ProximityRule;
}
