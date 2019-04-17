// PlayerLocomotionStateEvent
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct PlayerLocomotionStateEvent
{
	public long SessionId;

	public LocomotionState State;
}
