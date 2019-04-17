// LayoutRectTransformSwitcherSettingsComponent
using ClubPenguin.UI;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class LayoutRectTransformSwitcherSettingsComponent : LayoutSwitcherSettingsComponent<RectTransform, RectTransformSettings, LayoutRectTransformSwitcherSettings>
{
	protected override void applySettings(RectTransform component, RectTransformSettings settings)
	{
		RectTransformSettingsComponent.ApplySettings(component, settings);
	}
}
