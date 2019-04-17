// DestroyTriggerAction
using ClubPenguin;
using ClubPenguin.Actions;
using UnityEngine;

public class DestroyTriggerAction : Action
{
	protected override void Update()
	{
		GameObject trigger = SceneRefs.ActionSequencer.GetTrigger(Owner);
		if (trigger != null)
		{
			Object.Destroy(trigger);
		}
		Completed();
	}
}
