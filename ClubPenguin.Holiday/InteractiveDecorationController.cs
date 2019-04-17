// InteractiveDecorationController
using ClubPenguin.Holiday;
using Disney.LaunchPadFramework;
using UnityEngine;

public class InteractiveDecorationController : MonoBehaviour
{
	public InteractiveDecorationTarget TargetObject;

	private int groupIndex;

	private int groupMax;

	private void Start()
	{
		groupIndex = 0;
		groupMax = base.transform.childCount;
		if (TargetObject == null)
		{
			Log.LogError(this, $"O_o\t Error: {base.gameObject.GetPath()} does not have it's target object set");
		}
	}

	public void OnTargetHit()
	{
		Transform child = base.transform.GetChild(groupIndex);
		InteractiveDecorationGroup component = child.GetComponent<InteractiveDecorationGroup>();
		if (!(component != null))
		{
			return;
		}
		component.OnColorChange();
		if (++groupIndex >= groupMax)
		{
			groupIndex = 0;
			if (TargetObject != null)
			{
				TargetObject.OnColorChange();
			}
		}
	}
}
