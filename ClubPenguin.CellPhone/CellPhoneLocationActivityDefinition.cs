// CellPhoneLocationActivityDefinition
using ClubPenguin;
using ClubPenguin.CellPhone;
using System;
using UnityEngine;

[Serializable]
public class CellPhoneLocationActivityDefinition : CellPhoneActivityDefinition
{
	public SceneDefinition Scene;

	public Vector3 LocationInZone;

	public bool IsHiddenAfterAccessed;
}
