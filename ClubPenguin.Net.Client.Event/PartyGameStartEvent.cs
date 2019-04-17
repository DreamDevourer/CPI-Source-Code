// PartyGameStartEvent
using System;

[Serializable]
public struct PartyGameStartEvent
{
	public long owner;

	public long[] players;

	public int sessionId;

	public int templateId;
}
