// ZoomClampedSettings
using ClubPenguin.Core;
using System;
using UnityEngine;

[Serializable]
public struct ZoomClampedSettings
{
	public AspectRatioType Type;

	[Range(0f, 100f)]
	public float MinFOV;

	[Range(0f, 100f)]
	public float MaxFOV;
}
