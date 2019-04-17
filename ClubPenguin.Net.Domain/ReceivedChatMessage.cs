// ReceivedChatMessage
using System;

[Serializable]
public struct ReceivedChatMessage
{
	public long senderSessionId;

	public string message;

	public int emotion;
}
