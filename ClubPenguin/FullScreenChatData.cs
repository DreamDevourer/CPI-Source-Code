// FullScreenChatData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class FullScreenChatData : ScopedData
{
	[SerializeField]
	private int messageCount;

	public int MessageCount
	{
		get
		{
			return messageCount;
		}
		set
		{
			messageCount = value;
		}
	}

	protected override string scopeID => CPDataScopes.LocalPlayerZone.ToString();

	protected override Type monoBehaviourType => typeof(FullScreenChatDataMonoBehaviour);

	protected override void notifyWillBeDestroyed()
	{
	}
}
