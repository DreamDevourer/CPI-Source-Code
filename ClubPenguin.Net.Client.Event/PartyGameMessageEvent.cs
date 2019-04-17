// PartyGameMessageEvent
using System;

[Serializable]
public struct PartyGameMessageEvent
{
	public int sessionId;

	public int type;

	public string message;
}
