// AllAccessEventDefinition
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using Disney.MobileNetwork;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/AllAccessEventDefinition")]
public class AllAccessEventDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public string Id;

	public ScheduledEventDateDefinitionKey DateDefinitionKey;

	public bool ApplyToGoogleUsers;

	public bool ApplyToAppleUsers;

	public override string ToString()
	{
		ScheduledEventDateDefinition scheduledEventDateDefinition = Service.Get<IGameData>().Get<Dictionary<int, ScheduledEventDateDefinition>>()[DateDefinitionKey.Id];
		return $"[AllAccessEventDefinition] Id: {Id}, Start: {scheduledEventDateDefinition.Dates.StartDate}, End: {scheduledEventDateDefinition.Dates.EndDate}, Google={ApplyToGoogleUsers}, Apple={ApplyToAppleUsers}";
	}
}
