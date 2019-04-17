// AspectRatioSpecificSettingsComponent<TComponent,TSettings>
using ClubPenguin.Core;
using UnityEngine;

public abstract class AspectRatioSpecificSettingsComponent<TComponent, TSettings> : RuntimeSettingsComponent<TComponent, TSettings, AspectRatioType> where TComponent : Component where TSettings : AbstractAspectRatioSpecificSettings
{
	protected override TSettings getRuntimeSettings()
	{
		return PlatformUtils.FindAspectRatioSettings(runtimeSettings);
	}
}
