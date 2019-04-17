// SendInteractablesEventCommand
using ClubPenguin.Interactables.Domain;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("Interactables")]
public class SendInteractablesEventCommand : FsmStateAction
{
	public FsmOwnerDefault InteractableTarget;

	public InteractablesEvents.Actions Action;

	public override void OnEnter()
	{
		GameObject gameObject = (InteractableTarget.OwnerOption == OwnerDefaultOption.UseOwner) ? base.Owner : InteractableTarget.GameObject.Value;
		if (gameObject != null)
		{
			Service.Get<EventDispatcher>().DispatchEvent(new InteractablesEvents.ActionEvent(gameObject, Action));
		}
		Finish();
	}
}
