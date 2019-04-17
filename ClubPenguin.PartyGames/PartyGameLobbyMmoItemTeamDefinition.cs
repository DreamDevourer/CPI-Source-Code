// PartyGameLobbyMmoItemTeamDefinition
using ClubPenguin.Net.Domain;
using ClubPenguin.PartyGames;
using UnityEngine;

public class PartyGameLobbyMmoItemTeamDefinition : PartyGameLobbyDefinition
{
	public Vector3 LobbyLocation;

	public int LobbyProp;

	public int LobbyLengthInSeconds;

	public LocomotionState LobbyLocomotionState;

	public bool IsBlockingJumpToFriend;
}
