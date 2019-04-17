// ScheduleDefinition
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.DailyChallenge;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/Schedule")]
public class ScheduleDefinition : StaticGameDataDefinition
{
	[TextArea]
	public string Description;

	public DailyChallengeDefinitionContentKey[] Assets;
}
