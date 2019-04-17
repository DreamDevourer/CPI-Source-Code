// PropToBeRestoredData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class PropToBeRestoredData : ScopedData
{
	[SerializeField]
	private string propId;

	public string PropId
	{
		get
		{
			return propId;
		}
		set
		{
			propId = value;
		}
	}

	protected override Type monoBehaviourType => typeof(PropToBeRestoredDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override void notifyWillBeDestroyed()
	{
	}
}
