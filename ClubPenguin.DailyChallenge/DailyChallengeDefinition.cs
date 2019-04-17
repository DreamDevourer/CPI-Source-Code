// DailyChallengeDefinition
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.Task;
using System;
using System.IO;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/DailyChallenge")]
public class DailyChallengeDefinition : StaticGameDataDefinition
{
	[TextArea]
	public string Description;

	public TaskDefinitionContentKey TaskDefinitionContentKey;

	public string TaskName()
	{
		return Path.GetFileNameWithoutExtension(TaskDefinitionContentKey.Key);
	}
}
