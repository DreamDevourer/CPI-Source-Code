// SpawnAtPlayerData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class SpawnAtPlayerData : BaseData
{
	public string PlayerSWID
	{
		get;
		set;
	}

	public Vector3 PlayerPosition
	{
		get;
		set;
	}

	protected override Type monoBehaviourType => typeof(SpawnAtPlayerDataMonoBehaviour);

	protected override void notifyWillBeDestroyed()
	{
	}
}
