using ClubPenguin.Core;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using Fabric;
using System;
using UnityEngine;

namespace ClubPenguin.Audio
{
	internal class SceneMusic : MonoBehaviour
	{
		[Serializable]
		public class Snapshot
		{
			public string Name;

			public float TimeToReach;
		}

		public string EventOnEnter;

		public string EventName = "AudioMixer";

		public SceneMusic.Snapshot SnapshotOnEnter = new SceneMusic.Snapshot();

		public SceneMusic.Snapshot SnapshotOnExit = new SceneMusic.Snapshot();

		public string PersistToScene;

		private EventDispatcher dispatcher;

		private void Start()
		{
			this.dispatcher = Service.Get<EventDispatcher>();
			this.dispatcher.AddListener<SceneTransitionEvents.TransitionStart>(new EventHandlerDelegate<SceneTransitionEvents.TransitionStart>(this.onSceneTransitionStart), EventDispatcher.Priority.DEFAULT);
			this.startMusic();
		}

		private void OnDestroy()
		{
			if (this.dispatcher != null)
			{
				this.dispatcher.RemoveListener<SceneTransitionEvents.TransitionStart>(new EventHandlerDelegate<SceneTransitionEvents.TransitionStart>(this.onSceneTransitionStart));
			}
		}

		private bool onSceneTransitionStart(SceneTransitionEvents.TransitionStart evt)
		{
			if (evt.SceneName != this.PersistToScene)
			{
				if (!string.IsNullOrEmpty(this.SnapshotOnExit.Name))
				{
					TransitionToSnapshotData transitionToSnapshotData = new TransitionToSnapshotData();
					transitionToSnapshotData._snapshot = this.SnapshotOnExit.Name;
					transitionToSnapshotData._timeToReach = this.SnapshotOnExit.TimeToReach;
					EventManager.Instance.PostEvent(this.EventName, EventAction.TransitionToSnapshot, transitionToSnapshotData);
				}
			}
			return false;
		}

		private void startMusic()
		{
			if (!string.IsNullOrEmpty(this.EventOnEnter))
			{
				if (!EventManager.Instance.IsEventActive(this.EventOnEnter, null))
				{
					EventManager.Instance.PostEvent(this.EventOnEnter, EventAction.PlaySound, null);
					if (!string.IsNullOrEmpty(this.SnapshotOnEnter.Name))
					{
						TransitionToSnapshotData transitionToSnapshotData = new TransitionToSnapshotData();
						transitionToSnapshotData._snapshot = this.SnapshotOnEnter.Name;
						transitionToSnapshotData._timeToReach = this.SnapshotOnEnter.TimeToReach;
						EventManager.Instance.PostEvent(this.EventName, EventAction.TransitionToSnapshot, transitionToSnapshotData);
					}
				}
			}
		}
	}
}