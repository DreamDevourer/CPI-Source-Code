// PropActionButtonDelegates
using ClubPenguin.Core;
using ClubPenguin.Props;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;
using UnityEngine;

[RequireComponent(typeof(Prop))]
[DisallowMultipleComponent]
public class PropActionButtonDelegates : MonoBehaviour
{
	public event Action<InputEvents.Actions> ActionButtonPressed;

	public void Awake()
	{
		Service.Get<EventDispatcher>().AddListener<InputEvents.ActionEvent>(onActionEvent);
	}

	private bool onActionEvent(InputEvents.ActionEvent evt)
	{
		this.ActionButtonPressed(evt.Action);
		return false;
	}
}
