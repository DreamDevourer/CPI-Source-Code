// AlertsClearedEventArgs
using Disney.Mix.SDK;
using System.Collections.Generic;

public class AlertsClearedEventArgs : AbstractAlertsClearedEventArgs
{
	public AlertsClearedEventArgs(IEnumerable<IAlert> alerts)
	{
		base.Alerts = alerts;
	}
}
