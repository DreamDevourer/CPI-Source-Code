// MovePlayerToPositionAction
using ClubPenguin;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("Locomotion")]
public class MovePlayerToPositionAction : FsmStateAction
{
	[RequiredField]
	public FsmVector3 Position;

	public bool ChangeDirection;

	public FsmVector3 Direction;

	public override void OnEnter()
	{
		GameObject localPlayerGameObject = SceneRefs.ZoneLocalPlayerManager.LocalPlayerGameObject;
		localPlayerGameObject.transform.position = Position.Value;
		if (ChangeDirection)
		{
			localPlayerGameObject.transform.rotation = Quaternion.LookRotation(Direction.Value);
		}
		Finish();
	}
}
