// JoinRoomData
using ClubPenguin.Net.Domain;
using ClubPenguin.Net.Domain.Scene;
using System;
using System.Collections.Generic;

[Serializable]
public struct JoinRoomData
{
	public string swid;

	public string host;

	public int tcpPort;

	public int httpsPort;

	public string room;

	public long sessionId;

	public PlayerRoomData playerRoomData;

	public Dictionary<string, long> earnedRewards;

	public string userName;

	public MembershipRights membershipRights;

	public int selectedTubeId;

	public SceneLayout extraLayoutData;

	public string roomOwnerName;

	public bool roomOwner;
}
