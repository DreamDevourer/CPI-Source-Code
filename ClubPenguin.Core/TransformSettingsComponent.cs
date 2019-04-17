// TransformSettingsComponent
using ClubPenguin.Core;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Transform))]
public class TransformSettingsComponent : AspectRatioSpecificSettingsComponent<Transform, TransformSettings>
{
	protected override void applySettings(Transform component, TransformSettings settings)
	{
		component.localPosition = (settings.PositionOption ? settings.LocalPosition : component.localPosition);
		component.localScale = (settings.ScaleOption ? settings.Scale : component.localScale);
	}
}
