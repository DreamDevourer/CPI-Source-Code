// DailyChallengeScheduleDefinition
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.DailyChallenge;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/DailyChallengeSchedule")]
public class DailyChallengeScheduleDefinition : StaticGameDataDefinition
{
	public const string SCHEDULE_ASSET_FILENAME = "Schedule";

	[TextArea]
	public string Description;

	public DailyChallengeDefinitionContentKey[] Assets;

	public string CreationSettings;
}
