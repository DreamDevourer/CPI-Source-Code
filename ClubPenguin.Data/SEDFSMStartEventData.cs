// SEDFSMStartEventData
using ClubPenguin;
using ClubPenguin.Data;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class SEDFSMStartEventData : ScopedData
{
	public string EventName;

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override Type monoBehaviourType => typeof(SEDFSMStartEventDataMonoBehaviour);

	protected override void notifyWillBeDestroyed()
	{
	}
}
