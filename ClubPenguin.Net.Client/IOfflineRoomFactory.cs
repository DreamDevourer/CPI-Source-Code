// IOfflineRoomFactory
using ClubPenguin.Net.Client;
using System;

public interface IOfflineRoomFactory
{
	IOfflineRoomRunner Create(string room, Action<GameServerEvent, object> processEvent, Func<long> generateMMOItemId, OfflineGameServerClient.PartyGameSessionManager partyGameSessionManager);
}
