// SEDFSMStartEventSender
using ClubPenguin.Core;
using ClubPenguin.Data;
using Disney.Kelowna.Common.SEDFSM;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class SEDFSMStartEventSender : MonoBehaviour
{
	private StateMachine stateMachine;

	private void Start()
	{
		stateMachine = GetComponent<StateMachine>();
		if (stateMachine == null)
		{
			Log.LogErrorFormatted(this, "Ensure this component is added to gameobject that will contain a StateMachine component. Currently its on {0} gameobject", base.gameObject.name);
			return;
		}
		CPDataEntityCollection cPDataEntityCollection = Service.Get<CPDataEntityCollection>();
		if (cPDataEntityCollection.TryGetComponent(cPDataEntityCollection.LocalPlayerHandle, out SEDFSMStartEventData component))
		{
			stateMachine.SendEvent(component.EventName);
			cPDataEntityCollection.RemoveComponent<SEDFSMStartEventData>(cPDataEntityCollection.LocalPlayerHandle);
		}
	}
}
