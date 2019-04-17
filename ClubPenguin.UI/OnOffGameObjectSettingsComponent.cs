// OnOffGameObjectSettingsComponent
using ClubPenguin.Core;
using ClubPenguin.UI;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(OnOffGameObjectSelector))]
public class OnOffGameObjectSettingsComponent : AspectRatioSpecificSettingsComponent<OnOffGameObjectSelector, OnOffGameObjectSettings>
{
	public static void ApplySettings(OnOffGameObjectSelector component, OnOffGameObjectSettings settings)
	{
		component.IsOn = settings.IsOn;
	}

	protected override void applySettings(OnOffGameObjectSelector component, OnOffGameObjectSettings settings)
	{
		ApplySettings(component, settings);
	}
}
