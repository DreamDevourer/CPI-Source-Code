// ConditionDefinition_ScreenHeight
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Condition/Screen Height")]
public class ConditionDefinition_ScreenHeight : ConditionDefinition
{
	public int GreaterThanEqualToHeight;

	public override bool IsSatisfied()
	{
		int height = Screen.height;
		return height >= GreaterThanEqualToHeight;
	}
}
