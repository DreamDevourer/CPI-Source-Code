// CanvasScalerExtSettingsComponent
using ClubPenguin.Core;
using ClubPenguin.UI;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CanvasScalerExt))]
public class CanvasScalerExtSettingsComponent : AspectRatioSpecificSettingsComponent<CanvasScalerExt, CanvasScalerExtSettings>
{
	protected override void applySettings(CanvasScalerExt component, CanvasScalerExtSettings settings)
	{
		component.referenceResolution = new Vector2(settings.ReferenceResolutionX, settings.ReferenceResolutionY);
		component.ScaleModifierSmallDevice = settings.ScaleModifierSmallDevice;
		component.ScaleModifierLargeDevice = settings.ScaleModifierLargeDevice;
	}
}
