// CollisionRuleDefinition
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/Igloo/CollisionRule")]
public class CollisionRuleDefinition : StaticGameDataDefinition
{
	public CollisionRuleSetDefinitionKey InstalledItem;

	public CollisionRuleResult Result;

	public override string ToString()
	{
		return "InstalledItem: " + InstalledItem + ", Result: " + Result;
	}
}
