using Fabric;
using System;
using UnityEngine;

namespace ClubPenguin.Audio
{
	internal class AnimToFabricEvents : MonoBehaviour
	{
		public bool Mute;

		public GameObject OverrideSoundSource;

		private GameObject getSoundSource()
		{
			return (this.OverrideSoundSource != null) ? this.OverrideSoundSource : base.gameObject;
		}

		public void FabricPlaySound(string name)
		{
			if (!this.Mute)
			{
				EventManager.Instance.PostEvent(name, EventAction.PlaySound, this.getSoundSource());
			}
		}

		public void FabricPauseSound(string name)
		{
			if (!this.Mute)
			{
				EventManager.Instance.PostEvent(name, EventAction.PauseSound, this.getSoundSource());
			}
		}

		public void FabricUnpauseSound(string name)
		{
			if (!this.Mute)
			{
				EventManager.Instance.PostEvent(name, EventAction.UnpauseSound, this.getSoundSource());
			}
		}

		public void FabricStopSound(string name)
		{
			if (!this.Mute)
			{
				EventManager.Instance.PostEvent(name, EventAction.StopSound, this.getSoundSource());
			}
		}

		public void FabricStopAllSound(string name)
		{
			if (!this.Mute)
			{
				EventManager.Instance.PostEvent(name, EventAction.StopAll, this.getSoundSource());
			}
		}

		public void FabricSetVolume(string name, float volume)
		{
			if (!this.Mute)
			{
				EventManager.Instance.PostEvent(name, EventAction.SetVolume, volume, this.getSoundSource());
			}
		}

		public void FabricSetPitch(string name, float pitch)
		{
			if (!this.Mute)
			{
				EventManager.Instance.PostEvent(name, EventAction.SetPitch, pitch, this.getSoundSource());
			}
		}
	}
}