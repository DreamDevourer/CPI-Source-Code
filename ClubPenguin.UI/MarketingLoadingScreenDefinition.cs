// MarketingLoadingScreenDefinition
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using Disney.Kelowna.Common;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/MarketingLoadingScreenDefinition")]
public class MarketingLoadingScreenDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public int Id;

	public PrefabContentKey[] ScreenPrefabContentKeys;

	public ScheduledEventDateDefinitionKey DateDefinitionKey;
}
