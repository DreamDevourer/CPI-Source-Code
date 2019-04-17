// OfflineRoomFactory
using ClubPenguin;
using ClubPenguin.Net.Client;
using System;

public class OfflineRoomFactory : IOfflineRoomFactory
{
	public IOfflineRoomRunner Create(string roomName, Action<GameServerEvent, object> processEvent, Func<long> generateMMOItemId, OfflineGameServerClient.PartyGameSessionManager partyGameSessionManager)
	{
		return new OfflineRoomRunner(roomName, processEvent, generateMMOItemId, partyGameSessionManager);
	}
}
