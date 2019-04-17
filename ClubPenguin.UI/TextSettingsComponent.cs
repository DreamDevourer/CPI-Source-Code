// TextSettingsComponent
using ClubPenguin.Core;
using ClubPenguin.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[DisallowMultipleComponent]
public class TextSettingsComponent : AspectRatioSpecificSettingsComponent<Text, TextSettings>
{
	protected override void applySettings(Text component, TextSettings settings)
	{
		component.fontSize = settings.FontSize;
	}
}
