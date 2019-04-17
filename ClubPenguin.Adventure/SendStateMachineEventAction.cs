// SendStateMachineEventAction
using ClubPenguin.Core;
using Disney.Kelowna.Common.SEDFSM;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GUI")]
public class SendStateMachineEventAction : FsmStateAction
{
	[RequiredField]
	public string StateMachineName;

	[RequiredField]
	public string EventName;

	public override void OnEnter()
	{
		GameObject gameObject = GameObject.FindWithTag(UIConstants.Tags.UI_Tray_Root);
		if (gameObject != null)
		{
			StateMachineContext component = gameObject.GetComponent<StateMachineContext>();
			component.SendEvent(new ExternalEvent(StateMachineName, EventName));
		}
		Finish();
	}
}
