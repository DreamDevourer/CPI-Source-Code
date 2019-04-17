// DecorationRenderData
using System;
using UnityEngine;

[Serializable]
public class DecorationRenderData : ScriptableObject
{
	public Vector3 ItemPosition;

	public Quaternion ItemRotation;

	public Quaternion CameraRotation;

	public float CameraFOV;

	public override string ToString()
	{
		return $"[DecorationRenderData] ItemPosition: {ItemPosition}, ItemRotation: {ItemRotation}, CameraRotation: {CameraRotation}, CameraFOV: {CameraFOV}";
	}
}
