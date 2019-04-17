using Fabric;
using HutongGames.PlayMaker;
using System;
using UnityEngine;

namespace ClubPenguin.Audio
{
	[ActionCategory("Quest(Fabric)")]
	public class FabricSetSwitchAction : FsmStateAction
	{
		public FsmString EventName;

		public FsmString SwitchTo;

		public FsmGameObject TheObject;

		public override void OnEnter()
		{
			GameObject parentGameObject = this.TheObject.IsNone ? null : this.TheObject.Value;
			EventManager.Instance.PostEvent(this.EventName.Value, EventAction.SetSwitch, this.SwitchTo.Value, parentGameObject);
			base.Finish();
		}
	}
}