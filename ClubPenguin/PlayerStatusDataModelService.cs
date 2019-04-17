// PlayerStatusDataModelService
using ClubPenguin;
using ClubPenguin.Adventure;
using ClubPenguin.Net;
using Disney.Kelowna.Common.DataModel;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;

public class PlayerStatusDataModelService : AbstractDataModelService
{
	private void Awake()
	{
		Service.Get<EventDispatcher>().AddListener<QuestEvents.QuestUpdated>(onQuestUpdated);
		Service.Get<EventDispatcher>().AddListener<QuestServiceEvents.PlayerOnQuest>(onRemoteQuestUpdated);
	}

	private bool onQuestUpdated(QuestEvents.QuestUpdated evt)
	{
		setPlayerStatusData(dataEntityCollection.LocalPlayerHandle, evt.Quest.State == Quest.QuestState.Active, evt.Quest.Mascot.Name);
		return false;
	}

	private bool onRemoteQuestUpdated(QuestServiceEvents.PlayerOnQuest evt)
	{
		if (dataEntityCollection.TryFindEntity<SessionIdData, long>(evt.SessionId, out DataEntityHandle dataEntityHandle))
		{
			setPlayerStatusData(dataEntityHandle, !string.IsNullOrEmpty(evt.MascotName), evt.MascotName);
		}
		return false;
	}

	private void setPlayerStatusData(DataEntityHandle handle, bool active, string mascotName)
	{
		if (active)
		{
			if (!dataEntityCollection.TryGetComponent(handle, out PlayerStatusData component))
			{
				component = dataEntityCollection.AddComponent<PlayerStatusData>(handle);
			}
			component.QuestMascotName = mascotName;
		}
		else if (!handle.IsNull)
		{
			dataEntityCollection.RemoveComponent<PlayerStatusData>(handle);
		}
	}
}
