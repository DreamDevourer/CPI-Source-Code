// StructureRenderData
using System;
using UnityEngine;

[Serializable]
public class StructureRenderData : ScriptableObject
{
	public Vector3 ItemPosition;

	public Quaternion ItemRotation;

	public Quaternion CameraRotation;

	public float CameraFOV;

	public override string ToString()
	{
		return $"[StructureRenderData] ItemPosition: {ItemPosition}, ItemRotation: {ItemRotation}, CameraRotation: {CameraRotation}, CameraFOV: {CameraFOV}";
	}
}
