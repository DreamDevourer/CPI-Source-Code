// ConditionDefinition_ProcessorCount
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Condition/Processor Count")]
public class ConditionDefinition_ProcessorCount : ConditionDefinition
{
	public int LessThanEqualToCount;

	public override bool IsSatisfied()
	{
		int processorCount = SystemInfo.processorCount;
		return processorCount <= LessThanEqualToCount;
	}
}
