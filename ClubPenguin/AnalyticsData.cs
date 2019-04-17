// AnalyticsData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections.Generic;

[Serializable]
public class AnalyticsData : ScopedData
{
	private HashSet<string> singularCalls = new HashSet<string>();

	public HashSet<string> SingularCalls => singularCalls;

	protected override Type monoBehaviourType => typeof(AnalyticsDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override void notifyWillBeDestroyed()
	{
	}
}
