// QuestState
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class QuestState
{
	public string questId;

	public QuestStatus status;

	public QuestObjectives completedObjectives;

	public long? unlockTime;

	public int timesCompleted;
}
