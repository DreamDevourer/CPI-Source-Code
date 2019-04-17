// WaitForActivationAction
using ClubPenguin.Actions;
using UnityEngine;

public class WaitForActivationAction : Action
{
	public GameObject TheObject;

	protected override void CopyTo(Action _destWarper)
	{
		WaitForActivationAction waitForActivationAction = _destWarper as WaitForActivationAction;
		waitForActivationAction.TheObject = TheObject;
		base.CopyTo(_destWarper);
	}

	protected override void Update()
	{
		if (TheObject == null || TheObject.activeInHierarchy)
		{
			Completed();
		}
	}
}
