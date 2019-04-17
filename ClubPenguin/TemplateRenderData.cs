// TemplateRenderData
using System;
using UnityEngine;

[Serializable]
public class TemplateRenderData : ScriptableObject
{
	public Vector3 ItemPosition;

	public Quaternion ItemRotation;

	public Quaternion CameraRotation;

	public float CameraFOV;

	public override string ToString()
	{
		return $"[TemplateRenderData] ItemPosition: {ItemPosition}, ItemRotation: {ItemRotation}, CameraRotation: {CameraRotation}, CameraFOV: {CameraFOV}";
	}
}
