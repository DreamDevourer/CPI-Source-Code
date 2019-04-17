// SceneOwnerData
using ClubPenguin;
using ClubPenguin.Core;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class SceneOwnerData : ScopedData
{
	public string Name;

	public bool IsOwner;

	protected override string scopeID => CPDataScopes.Zone.ToString();

	protected override Type monoBehaviourType => typeof(SceneOwnerDataMonoBehaviour);

	protected override void notifyWillBeDestroyed()
	{
	}
}
