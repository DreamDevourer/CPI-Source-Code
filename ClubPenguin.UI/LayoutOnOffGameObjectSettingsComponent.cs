// LayoutOnOffGameObjectSettingsComponent
using ClubPenguin.UI;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(OnOffGameObjectSelector))]
public class LayoutOnOffGameObjectSettingsComponent : LayoutSwitcherSettingsComponent<OnOffGameObjectSelector, OnOffGameObjectSettings, LayoutOnOffGameObjectSettings>
{
	protected override void applySettings(OnOffGameObjectSelector component, OnOffGameObjectSettings settings)
	{
		OnOffGameObjectSettingsComponent.ApplySettings(component, settings);
	}
}
