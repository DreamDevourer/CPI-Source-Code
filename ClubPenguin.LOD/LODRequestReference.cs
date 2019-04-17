// LODRequestReference
using ClubPenguin;
using ClubPenguin.LOD;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class LODRequestReference : ScopedData
{
	public LODRequest Request;

	protected override Type monoBehaviourType => typeof(LODRequestReferenceMonoBehaviour);

	protected override string scopeID => CPDataScopes.Scene.ToString();

	protected override void notifyWillBeDestroyed()
	{
	}
}
