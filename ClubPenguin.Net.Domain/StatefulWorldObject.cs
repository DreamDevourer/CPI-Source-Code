// StatefulWorldObject
using ClubPenguin.Net.Client.Smartfox;
using ClubPenguin.Net.Domain;
using Disney.Manimal.Common.Util;
using Sfs2X.Entities;
using System;

[Serializable]
public class StatefulWorldObject : CPMMOItem
{
	public string Path;

	public long Timestamp;

	public ScheduledWorldObjectState State;

	public DateTime DateTime => Timestamp.MsToDateTime();

	public StatefulWorldObject()
	{
	}

	public StatefulWorldObject(IMMOItem sfsItem)
	{
		Path = sfsItem.GetVariable(SocketItemVars.GAME_OBJECT_PATH.GetKey()).GetStringValue();
		Timestamp = long.Parse(sfsItem.GetVariable(SocketItemVars.STATE_TIMESTAMP.GetKey()).GetStringValue());
		State = (ScheduledWorldObjectState)sfsItem.GetVariable(SocketItemVars.SCHEDULED_WORLD_OBJECT_STATE.GetKey()).GetIntValue();
	}
}
