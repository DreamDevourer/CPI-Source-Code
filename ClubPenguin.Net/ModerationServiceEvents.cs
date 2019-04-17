// ModerationServiceEvents
using ClubPenguin.Net;
using System.Collections.Generic;

public static class ModerationServiceEvents
{
	public struct ShowAlerts
	{
		public readonly IEnumerable<IModerationAlert> Alerts;

		public ShowAlerts(IEnumerable<IModerationAlert> alerts)
		{
			Alerts = alerts;
		}
	}
}
