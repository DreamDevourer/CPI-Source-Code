// IEventListener
using Fabric;
using System.Collections.Generic;
using UnityEngine;

public interface IEventListener
{
	bool IsDestroyed
	{
		get;
	}

	EventStatus Process(Fabric.Event postedEvent);

	bool GetEventListeners(string eventName, List<EventListener> listeners);

	bool GetEventListeners(int eventID, List<EventListener> listeners);

	bool IsActive(GameObject parentGameObject);

	bool GetEventInfo(GameObject parentGameObject, ref EventInfo eventInfo);
}
