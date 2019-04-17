// ConditionDefinition_Default
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Condition/Default")]
public class ConditionDefinition_Default : ConditionDefinition
{
	public override bool IsSatisfied()
	{
		return true;
	}
}
