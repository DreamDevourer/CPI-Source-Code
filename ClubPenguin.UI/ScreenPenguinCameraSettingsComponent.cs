// ScreenPenguinCameraSettingsComponent
using ClubPenguin.Core;
using ClubPenguin.UI;
using UnityEngine;

[RequireComponent(typeof(ScreenPenguinCamera))]
[DisallowMultipleComponent]
public class ScreenPenguinCameraSettingsComponent : AspectRatioSpecificSettingsComponent<ScreenPenguinCamera, ScreenPenguinCameraSettings>
{
	protected override void applySettings(ScreenPenguinCamera component, ScreenPenguinCameraSettings settings)
	{
		component.ZoomPercentage = settings.ZoomPercentage;
		component.ZoomHeightOffset = settings.ZoomHeightOffset;
		component.ZoomMinDist = settings.ZoomMinDist;
	}
}
