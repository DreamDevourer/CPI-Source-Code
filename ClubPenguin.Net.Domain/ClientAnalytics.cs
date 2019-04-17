// ClientAnalytics
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct ClientAnalytics
{
	public ClientAnalyticsHardware hardware;

	public ClientAnalyticsAction action;
}
