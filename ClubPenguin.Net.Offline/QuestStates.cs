// QuestStates
using ClubPenguin.Net.Domain;
using ClubPenguin.Net.Offline;
using System;
using System.Collections.Generic;

public struct QuestStates : IOfflineData
{
	public class QuestState : ClubPenguin.Net.Domain.QuestState
	{
		public DateTime completedTime;
	}

	public List<QuestState> Quests;

	public void Init()
	{
		Quests = new List<QuestState>();
	}
}
