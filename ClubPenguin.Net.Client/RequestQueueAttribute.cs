// RequestQueueAttribute
using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class RequestQueueAttribute : Attribute
{
	public readonly string QueueId;

	public RequestQueueAttribute(string queueId)
	{
		QueueId = queueId;
	}
}
