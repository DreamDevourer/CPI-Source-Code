using Fabric;
using HutongGames.PlayMaker;
using System;

namespace ClubPenguin.Audio
{
	[ActionCategory("Quest(Fabric)")]
	public class FabricTransitionToSnapshotAction : FsmStateAction
	{
		public FsmString EventName = "AudioMixer";

		public FsmString Snapshot;

		public FsmFloat TimeToReach;

		public override void OnEnter()
		{
			TransitionToSnapshotData transitionToSnapshotData = new TransitionToSnapshotData();
			transitionToSnapshotData._snapshot = (this.Snapshot.IsNone ? "" : this.Snapshot.Value);
			transitionToSnapshotData._timeToReach = (this.TimeToReach.IsNone ? 0f : this.TimeToReach.Value);
			EventManager.Instance.PostEvent(this.EventName.Value, EventAction.TransitionToSnapshot, transitionToSnapshotData);
			base.Finish();
		}
	}
}