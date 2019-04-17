// AlertsAddedEventArgs
using Disney.Mix.SDK;
using System.Collections.Generic;

public class AlertsAddedEventArgs : AbstractAlertsAddedEventArgs
{
	public AlertsAddedEventArgs(IEnumerable<IAlert> alerts)
	{
		base.Alerts = alerts;
	}
}
