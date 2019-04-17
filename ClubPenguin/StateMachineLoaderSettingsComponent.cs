// StateMachineLoaderSettingsComponent
using ClubPenguin;
using ClubPenguin.Core;
using Disney.Kelowna.Common.SEDFSM;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(StateMachineLoader))]
public class StateMachineLoaderSettingsComponent : AspectRatioSpecificSettingsComponent<StateMachineLoader, ClubPenguin.StateMachineLoaderSettings>
{
	protected override void applySettings(StateMachineLoader component, ClubPenguin.StateMachineLoaderSettings settings)
	{
		for (int i = 0; i < settings.BindingOverrides.Length; i++)
		{
			StateMachineLoader.Binding binding = settings.BindingOverrides[i];
			for (int j = 0; j < component.Bindings.Length; j++)
			{
				if (binding.Name == component.Bindings[j].Name)
				{
					component.Bindings[j] = binding;
				}
			}
		}
	}
}
