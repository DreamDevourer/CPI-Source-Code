using Fabric;
using HutongGames.PlayMaker;
using System;

namespace ClubPenguin.Audio
{
	[ActionCategory("Quest(Fabric)")]
	public class FabricSetVolumeAction : FsmStateAction
	{
		public FsmString EventName;

		public FsmFloat Volume;

		public override void OnEnter()
		{
			float num = this.Volume.IsNone ? 0f : this.Volume.Value;
			EventManager.Instance.PostEvent(this.EventName.Value, EventAction.SetVolume, num);
			base.Finish();
		}
	}
}