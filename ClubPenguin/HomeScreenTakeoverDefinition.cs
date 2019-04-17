// HomeScreenTakeoverDefinition
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using Disney.Kelowna.Common;
using UnityEngine;

[CreateAssetMenu(menuName = "Definition/HomeScreenTakeoverDefinition")]
public class HomeScreenTakeoverDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public string Id;

	public PrefabContentKey TakeOverPrefabContentKey;

	public ScheduledEventDateDefinitionKey DateDefinitionKey;
}
