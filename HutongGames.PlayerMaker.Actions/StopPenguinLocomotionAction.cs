// StopPenguinLocomotionAction
using ClubPenguin;
using ClubPenguin.Locomotion;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("Locomotion")]
public class StopPenguinLocomotionAction : FsmStateAction
{
	public override void OnEnter()
	{
		GameObject localPlayerGameObject = SceneRefs.ZoneLocalPlayerManager.LocalPlayerGameObject;
		if (localPlayerGameObject != null)
		{
			LocomotionController currentController = LocomotionHelper.GetCurrentController(localPlayerGameObject);
			if (currentController != null)
			{
				currentController.ResetState();
			}
		}
		Finish();
	}
}
