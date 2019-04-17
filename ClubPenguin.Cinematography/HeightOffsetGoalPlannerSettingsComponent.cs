// HeightOffsetGoalPlannerSettingsComponent
using ClubPenguin.Cinematography;
using ClubPenguin.Core;
using UnityEngine;

[RequireComponent(typeof(HeightOffsetGoalPlanner))]
[DisallowMultipleComponent]
public class HeightOffsetGoalPlannerSettingsComponent : AspectRatioSpecificSettingsComponent<HeightOffsetGoalPlanner, HeightOffsetGoalPlannerSettings>
{
	protected override void applySettings(HeightOffsetGoalPlanner component, HeightOffsetGoalPlannerSettings settings)
	{
		component.Height = settings.Height;
	}
}
