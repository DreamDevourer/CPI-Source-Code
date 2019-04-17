// BackButtonStateHandlerSettingsComponent
using ClubPenguin;
using ClubPenguin.Core;
using UnityEngine;

[RequireComponent(typeof(BackButtonStateHandler))]
[DisallowMultipleComponent]
public class BackButtonStateHandlerSettingsComponent : AspectRatioSpecificSettingsComponent<BackButtonStateHandler, BackButtonStateHandlerSettings>
{
	protected override void applySettings(BackButtonStateHandler component, BackButtonStateHandlerSettings settings)
	{
		component.LastStateEvent = settings.LastStateEvent;
	}
}
