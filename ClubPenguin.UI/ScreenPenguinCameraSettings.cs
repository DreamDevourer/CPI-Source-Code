// ScreenPenguinCameraSettings
using ClubPenguin.Core;
using System;

[Serializable]
public class ScreenPenguinCameraSettings : AbstractAspectRatioSpecificSettings
{
	public float ZoomPercentage;

	public float ZoomHeightOffset;

	public float ZoomMinDist;
}
