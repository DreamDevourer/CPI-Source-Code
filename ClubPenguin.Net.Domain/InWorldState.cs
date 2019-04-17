// InWorldState
using ClubPenguin.Net.Domain;
using System;
using UnityEngine;

[Serializable]
public struct InWorldState
{
	public RoomIdentifier location;

	public Vector3 position;

	public string equippedItem;
}
