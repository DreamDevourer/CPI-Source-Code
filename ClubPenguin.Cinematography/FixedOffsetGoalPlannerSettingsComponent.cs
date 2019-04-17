// FixedOffsetGoalPlannerSettingsComponent
using ClubPenguin.Cinematography;
using ClubPenguin.Core;
using UnityEngine;

[RequireComponent(typeof(FixedOffsetGoalPlanner))]
[DisallowMultipleComponent]
public class FixedOffsetGoalPlannerSettingsComponent : AspectRatioSpecificSettingsComponent<FixedOffsetGoalPlanner, FixedOffsetGoalPlannerSettings>
{
	protected override void applySettings(FixedOffsetGoalPlanner component, FixedOffsetGoalPlannerSettings settings)
	{
		component.Offset = settings.Offset;
	}
}
