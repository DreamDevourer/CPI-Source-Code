// ConditionDefinition_Platform
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Condition/Platform")]
public class ConditionDefinition_Platform : ConditionDefinition
{
	public RuntimePlatform Platform;

	public override bool IsSatisfied()
	{
		RuntimePlatform platform = Application.platform;
		return platform == Platform;
	}
}
