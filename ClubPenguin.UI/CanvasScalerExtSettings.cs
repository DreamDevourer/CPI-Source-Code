// CanvasScalerExtSettings
using ClubPenguin.Core;
using System;

[Serializable]
public class CanvasScalerExtSettings : AbstractAspectRatioSpecificSettings
{
	public float ReferenceResolutionX;

	public float ReferenceResolutionY;

	public float ScaleModifierSmallDevice;

	public float ScaleModifierLargeDevice;
}
