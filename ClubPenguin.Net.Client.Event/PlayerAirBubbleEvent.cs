// PlayerAirBubbleEvent
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct PlayerAirBubbleEvent
{
	public AirBubble AirBubble;

	public long SessionId
	{
		get;
		set;
	}
}
