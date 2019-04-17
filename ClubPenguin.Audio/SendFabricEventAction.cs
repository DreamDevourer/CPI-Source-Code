using Fabric;
using HutongGames.PlayMaker;
using System;
using UnityEngine;

namespace ClubPenguin.Audio
{
	[ActionCategory("Misc")]
	public class SendFabricEventAction : FsmStateAction
	{
		public FsmString EventName;

		public FsmGameObject OverrideSoundSource;

		public EventAction EventAction = EventAction.PlaySound;

		public override void OnEnter()
		{
			GameObject parentGameObject = this.OverrideSoundSource.IsNone ? base.Owner : this.OverrideSoundSource.Value;
			EventManager.Instance.PostEvent(this.EventName.Value, this.EventAction, parentGameObject);
			base.Finish();
		}
	}
}