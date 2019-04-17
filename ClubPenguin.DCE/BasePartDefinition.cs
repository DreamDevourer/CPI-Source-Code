// BasePartDefinition
using ClubPenguin.DCE;
using UnityEngine;

public abstract class BasePartDefinition : ScriptableObject
{
	public abstract void ApplyToViewPart(ViewPart partView);
}
