// IQuestService
using ClubPenguin.Net;
using ClubPenguin.Net.Domain;

public interface IQuestService : INetworkService
{
	QuestStatus? PendingSetStatusStatus
	{
		get;
	}

	void SetStatus(string questId, QuestStatus status);

	void CompleteObjective(string objective);

	void RestartQuest(string questId);

	void ClearQueue();

	void QA_SetProgress(QuestObjectives objectives);

	void QA_ResetQuest(string questId);

	void QA_UnlockQuest(string questId);

	void QA_SetStatus(string questId, QuestStatus status);
}
