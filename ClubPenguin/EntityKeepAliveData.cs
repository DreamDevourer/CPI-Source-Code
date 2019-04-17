// EntityKeepAliveData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class EntityKeepAliveData : ScopedData
{
	protected override Type monoBehaviourType => typeof(EntityKeepAliveDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Application.ToString();

	protected override void notifyWillBeDestroyed()
	{
	}
}
