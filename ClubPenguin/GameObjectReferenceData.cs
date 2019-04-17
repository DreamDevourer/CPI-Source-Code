// GameObjectReferenceData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class GameObjectReferenceData : ScopedData
{
	[SerializeField]
	private GameObject gameObjectReference;

	public GameObject GameObject
	{
		get
		{
			return gameObjectReference;
		}
		set
		{
			gameObjectReference = value;
		}
	}

	protected override Type monoBehaviourType => typeof(GameObjectReferenceDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Scene.ToString();

	protected override void notifyWillBeDestroyed()
	{
		gameObjectReference = null;
	}
}
