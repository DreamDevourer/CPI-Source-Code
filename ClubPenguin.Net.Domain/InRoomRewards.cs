// InRoomRewards
using System;
using System.Collections.Generic;

[Serializable]
public struct InRoomRewards
{
	public string room;

	public Dictionary<string, long> collected;
}
