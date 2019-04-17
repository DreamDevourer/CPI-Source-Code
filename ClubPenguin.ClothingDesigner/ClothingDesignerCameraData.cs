// ClothingDesignerCameraData
using ClubPenguin.ClothingDesigner;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class ClothingDesignerCameraData : ScriptableObject
{
	public ClothingDesignerCameraState State;

	public Vector3 Position;

	public Vector3 Rotation;
}
