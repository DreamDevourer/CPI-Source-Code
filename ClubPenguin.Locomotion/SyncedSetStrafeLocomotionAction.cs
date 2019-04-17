// SyncedSetStrafeLocomotionAction
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("Locomotion")]
public class SyncedSetStrafeLocomotionAction : FsmStateAction
{
	public FsmString Target;

	public bool ForwardAsUp;

	public bool StickRelative;

	public override void OnEnter()
	{
		GameObject x = GameObject.Find(Target.Value);
		if (x != null)
		{
		}
		Finish();
	}
}
