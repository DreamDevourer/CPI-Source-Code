// GateData
using ClubPenguin;
using ClubPenguin.ContentGates;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections.Generic;

[Serializable]
internal class GateData : ScopedData
{
	public Dictionary<Type, bool> GateStatus
	{
		get;
		set;
	}

	protected override Type monoBehaviourType => typeof(GateDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Application.ToString();

	protected override void notifyWillBeDestroyed()
	{
	}
}
