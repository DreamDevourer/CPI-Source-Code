// AbstractAlertsAddedEventArgs
using Disney.Mix.SDK;
using System;
using System.Collections.Generic;

public abstract class AbstractAlertsAddedEventArgs : EventArgs
{
	public IEnumerable<IAlert> Alerts
	{
		get;
		protected set;
	}
}
