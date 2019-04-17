// LocomotionActionEvent
using ClubPenguin.Net.Client.Event;
using ClubPenguin.Net.Domain;
using System;
using UnityEngine;

[Serializable]
public struct LocomotionActionEvent
{
	public long SessionId;

	public LocomotionAction Type;

	public long Timestamp;

	public Vector3 Position;

	public Vector3? Direction;

	public Vector3? Velocity;

	public ActionedObject Object;
}
