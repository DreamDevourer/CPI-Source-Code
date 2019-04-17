// ActionedItem
using ClubPenguin.Net.Client.Smartfox;
using ClubPenguin.Net.Domain;
using Sfs2X.Entities;
using System;

[Serializable]
public class ActionedItem : TimedItem
{
	public int ActionCount;

	public ActionedItem(IMMOItem sfsItem)
		: base(sfsItem)
	{
		ActionCount = sfsItem.GetVariable(SocketItemVars.ACTION_COUNT.GetKey()).GetIntValue();
	}

	public ActionedItem(float timeToLive, int actionCount)
		: base(timeToLive)
	{
		ActionCount = actionCount;
	}
}
