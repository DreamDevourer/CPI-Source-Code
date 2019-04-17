// ImageSettingsComponent
using ClubPenguin.Core;
using ClubPenguin.UI;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Image))]
public class ImageSettingsComponent : AspectRatioSpecificSettingsComponent<Image, ImageSettings>
{
	protected override void applySettings(Image component, ImageSettings settings)
	{
		component.sprite = settings.Sprite;
	}
}
