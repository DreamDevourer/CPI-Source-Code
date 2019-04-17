// PlayerLocoStyle
using ClubPenguin.Net.Client.Event;
using System;

[Serializable]
public struct PlayerLocoStyle
{
	public enum Style : byte
	{
		Walk = 1,
		Run
	}

	public long sessionId;

	public Style style;
}
