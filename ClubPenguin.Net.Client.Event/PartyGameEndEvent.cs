// PartyGameEndEvent
using System;
using System.Collections.Generic;

[Serializable]
public struct PartyGameEndEvent
{
	public Dictionary<long, int> playerSessionIdToPlacement;

	public int sessionId;
}
