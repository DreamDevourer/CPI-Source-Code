// ChatHistoryData
using ClubPenguin;
using ClubPenguin.Chat;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChatHistoryData : ScopedData
{
	[SerializeField]
	public const int MAX_HISTORY_SIZE = 50;

	[SerializeField]
	private Queue<DChatMessage> messageHistory = new FixedSizeQueue<DChatMessage>(50);

	public IList<DChatMessage> MessageHistory
	{
		get
		{
			List<DChatMessage> list = new List<DChatMessage>();
			foreach (DChatMessage item in messageHistory)
			{
				list.Add(item);
			}
			return list.AsReadOnly();
		}
	}

	protected override string scopeID => CPDataScopes.Zone.ToString();

	protected override Type monoBehaviourType => typeof(ChatHistoryDataMonoBehaviour);

	public void AddMessage(DChatMessage message)
	{
		messageHistory.Enqueue(message);
	}

	protected override void notifyWillBeDestroyed()
	{
	}
}
