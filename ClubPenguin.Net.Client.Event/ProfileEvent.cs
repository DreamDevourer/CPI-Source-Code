// ProfileEvent
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct ProfileEvent
{
	public long SessionId;

	public Profile Profile;
}
