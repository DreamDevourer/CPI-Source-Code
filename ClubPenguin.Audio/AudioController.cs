using Fabric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ClubPenguin.Audio
{
	public class AudioController : MonoBehaviour
	{
		private sealed class _otherAudioCheck_d__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private object __2__current;

			private int __1__state;

			public AudioController __4__this;

			object IEnumerator<object>.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			bool IEnumerator.MoveNext()
			{
				bool result;
				switch (this.__1__state)
				{
				case 0:
					this.__1__state = -1;
					break;
				case 1:
					this.__1__state = -1;
					break;
				default:
					result = false;
					return result;
				}
				if (!this.__4__this.muted)
				{
					this.__4__this.SetMusicVolume(this.__4__this.cachedMusicVolume);
				}
				this.__2__current = new WaitForSeconds(1f);
				this.__1__state = 1;
				result = true;
				return result;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			public _otherAudioCheck_d__0(int __1__state)
			{
				this.__1__state = __1__state;
			}
		}

		public GroupComponent AMB;

		public GroupComponent Music;

		public GroupComponent SFX;

		public GroupComponent DIA;

		private float cachedMusicVolume = 1f;

		private float cachedSFXVolume = 1f;

		private bool muted = false;

		public float MusicVolume
		{
			get
			{
				return this.Music.Volume;
			}
		}

		public float SFXVolume
		{
			get
			{
				return this.SFX.Volume;
			}
		}

		public void Initialize()
		{
			base.StartCoroutine(this.otherAudioCheck());
		}

		public void SetSFXVolume(float sfxVolume, bool cache = true)
		{
			this.AMB.Volume = sfxVolume;
			this.SFX.Volume = sfxVolume;
			this.DIA.Volume = sfxVolume;
			if (cache)
			{
				this.cachedSFXVolume = sfxVolume;
			}
		}

		public void SetMusicVolume(float musicVolume)
		{
			this.Music.Volume = musicVolume;
			if (this.isOtherAudioPlaying())
			{
				this.Music.Volume = 0f;
			}
			else
			{
				this.Music.Volume = musicVolume;
				this.cachedMusicVolume = musicVolume;
			}
		}

		private IEnumerator otherAudioCheck()
		{
			AudioController._otherAudioCheck_d__0 _otherAudioCheck_d__ = new AudioController._otherAudioCheck_d__0(0);
			_otherAudioCheck_d__.__4__this = this;
			return _otherAudioCheck_d__;
		}

		private bool isOtherAudioPlaying()
		{
			return false;
		}

		public void MuteAll(bool mute)
		{
			if (mute)
			{
				this.muted = true;
				this.Music.Volume = 0f;
				this.SetSFXVolume(0f, false);
			}
			else
			{
				this.muted = false;
				this.Music.Volume = this.cachedMusicVolume;
				this.SetSFXVolume(this.cachedSFXVolume, true);
			}
		}

		public void StopFabric()
		{
			FabricManager.Instance.Stop(1f);
		}
	}
}