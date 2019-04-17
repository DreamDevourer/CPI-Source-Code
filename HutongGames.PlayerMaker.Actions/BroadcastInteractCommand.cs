// BroadcastInteractCommand
using ClubPenguin.Locomotion;
using HutongGames.PlayMaker;

[ActionCategory("Locomotion")]
public class BroadcastInteractCommand : FsmStateAction
{
	public FsmOwnerDefault gameObject;

	public FsmGameObject targetGameObject;

	public override void OnEnter()
	{
		if (targetGameObject.IsNone || targetGameObject.Value == null)
		{
			targetGameObject = gameObject.GameObject;
		}
		LocomotionEventBroadcaster component = gameObject.GameObject.Value.GetComponent<LocomotionEventBroadcaster>();
		if (component != null)
		{
			component.BroadcastOnInteractionStarted(targetGameObject.Value);
		}
		Finish();
	}
}
