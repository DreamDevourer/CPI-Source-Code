// ConditionDefinition_ScreenPixelCount
using ClubPenguin.Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditional/Condition/Screen Pixel Count")]
public class ConditionDefinition_ScreenPixelCount : ConditionDefinition
{
	public int GreaterThanEqualToPixelCount;

	public override bool IsSatisfied()
	{
		int num = Screen.height * Screen.width;
		return num >= GreaterThanEqualToPixelCount;
	}
}
