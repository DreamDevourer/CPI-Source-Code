// ServerObjectPositionData
using ClubPenguin;
using ClubPenguin.Core;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class ServerObjectPositionData : ScopedData
{
	private Vector3 position;

	public Vector3 Position
	{
		get
		{
			return position;
		}
		set
		{
			changed(value);
			position = value;
		}
	}

	protected override Type monoBehaviourType => typeof(ServerObjectPositionDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Zone.ToString();

	public event Action<Vector3> PositionChanged;

	private void changed(Vector3 newItem)
	{
		if (this.PositionChanged != null)
		{
			this.PositionChanged(newItem);
		}
	}

	protected override void notifyWillBeDestroyed()
	{
	}
}
