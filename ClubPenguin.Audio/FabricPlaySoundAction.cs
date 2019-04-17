using Fabric;
using HutongGames.PlayMaker;
using System;
using UnityEngine;

namespace ClubPenguin.Audio
{
	[ActionCategory("Quest(Fabric)")]
	public class FabricPlaySoundAction : FsmStateAction
	{
		public FsmString EventName;

		public FsmGameObject OverrideSoundSource;

		public bool RestartIfPlaying = true;

		public override void OnEnter()
		{
			GameObject parentGameObject = this.OverrideSoundSource.IsNone ? null : this.OverrideSoundSource.Value;
			bool flag = true;
			if (!this.RestartIfPlaying)
			{
				flag = !EventManager.Instance.IsEventActive(this.EventName.Value, null);
			}
			if (flag)
			{
				EventManager.Instance.PostEvent(this.EventName.Value, EventAction.PlaySound, parentGameObject);
			}
			base.Finish();
		}
	}
}