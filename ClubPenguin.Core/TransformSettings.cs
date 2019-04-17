// TransformSettings
using ClubPenguin.Core;
using System;
using UnityEngine;

[Serializable]
public class TransformSettings : AbstractAspectRatioSpecificSettings
{
	public bool PositionOption;

	public bool ScaleOption;

	public Vector3 LocalPosition;

	public Vector3 Scale;
}
