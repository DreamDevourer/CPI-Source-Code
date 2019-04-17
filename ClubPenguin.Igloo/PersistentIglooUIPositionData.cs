// PersistentIglooUIPositionData
using ClubPenguin;
using ClubPenguin.Igloo;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class PersistentIglooUIPositionData : ScopedData
{
	public string ScreenName;

	public Vector2 Position;

	protected override string scopeID => CPDataScopes.Scene.ToString();

	protected override Type monoBehaviourType => typeof(PersistentIglooUIPositionDataMonoBehaviour);

	protected override void notifyWillBeDestroyed()
	{
	}
}
