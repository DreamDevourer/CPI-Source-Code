// PausedStateData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class PausedStateData : BaseData
{
	public bool ShouldSkipResume;

	public Vector3 Position
	{
		get;
		set;
	}

	protected override Type monoBehaviourType => typeof(PausedStateDataMonoBehaviour);

	protected override void notifyWillBeDestroyed()
	{
	}
}
