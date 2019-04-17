// EventChannel
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using System;
using System.Collections.Generic;

public class EventChannel
{
	public delegate void RemoveListenerDelegate();

	private readonly Dictionary<Delegate, RemoveListenerDelegate> handlers = new Dictionary<Delegate, RemoveListenerDelegate>();

	private readonly Dictionary<Delegate, Delegate> oneShotHandlers = new Dictionary<Delegate, Delegate>();

	private readonly EventDispatcher dispatcher;

	public EventChannel(EventDispatcher dispatcher)
	{
		this.dispatcher = dispatcher;
	}

	public void AddListener<TEvent>(EventHandlerDelegate<TEvent> handler, EventDispatcher.Priority priority = EventDispatcher.Priority.DEFAULT) where TEvent : struct
	{
		dispatcher.AddListener(handler, priority);
		handlers.Add(handler, delegate
		{
			dispatcher.RemoveListener(handler);
		});
	}

	public void AddListenerOneShot<TEvent>(EventHandlerDelegate<TEvent> handler, EventDispatcher.Priority priority = EventDispatcher.Priority.DEFAULT) where TEvent : struct
	{
		EventHandlerDelegate<TEvent> oneShotHandler = null;
		oneShotHandler = (EventHandlerDelegate<TEvent>)(EventHandlerDelegate<TEvent>)delegate(TEvent e)
		{
			dispatcher.RemoveListener((EventHandlerDelegate<TEvent>)oneShotHandler);
			return handler(e);
		};
		AddListener((EventHandlerDelegate<TEvent>)oneShotHandler, priority);
		oneShotHandlers.Add(handler, oneShotHandler);
	}

	public bool RemoveListener<TEvent>(EventHandlerDelegate<TEvent> handler) where TEvent : struct
	{
		bool result = false;
		if (!handlers.Remove(handler))
		{
			if (oneShotHandlers.TryGetValue(handler, out Delegate value))
			{
				handlers.Remove(value);
				oneShotHandlers.Remove(handler);
				result = dispatcher.RemoveListener((EventHandlerDelegate<TEvent>)value);
			}
		}
		else
		{
			result = dispatcher.RemoveListener(handler);
		}
		return result;
	}

	public void RemoveAllListeners()
	{
		foreach (KeyValuePair<Delegate, RemoveListenerDelegate> handler in handlers)
		{
			handler.Value();
		}
		handlers.Clear();
		oneShotHandlers.Clear();
	}
}
