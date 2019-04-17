// SetLocomotionControllerAction
using ClubPenguin;
using ClubPenguin.Locomotion;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("Locomotion")]
public class SetLocomotionControllerAction : FsmStateAction
{
	public override void OnEnter()
	{
		GameObject localPlayerGameObject = SceneRefs.ZoneLocalPlayerManager.LocalPlayerGameObject;
		if (localPlayerGameObject != null)
		{
			LocomotionHelper.SetCurrentController<RunController>(localPlayerGameObject);
			CharacterController component = localPlayerGameObject.GetComponent<CharacterController>();
			if (component != null)
			{
				component.enabled = true;
			}
		}
		Finish();
	}
}
