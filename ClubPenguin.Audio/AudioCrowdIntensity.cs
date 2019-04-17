using ClubPenguin.Core;
using Disney.Kelowna.Common;
using Fabric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ClubPenguin.Audio
{
	[RequireComponent(typeof(SphereCollider))]
	internal class AudioCrowdIntensity : MonoBehaviour
	{
		private sealed class _updateCount_d__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private object __2__current;

			private int __1__state;

			public AudioCrowdIntensity __4__this;

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
				this.__4__this.count = Physics.OverlapSphereNonAlloc(this.__4__this.spherePos, this.__4__this.sphereRadius, this.__4__this.colliders, this.__4__this.layerMask);
				if (!string.IsNullOrEmpty(this.__4__this.EventName))
				{
					EventManager.Instance.SetParameter(this.__4__this.EventName, this.__4__this.ParticipantCountRTP, (float)this.__4__this.count, this.__4__this.gameObject);
				}
				this.__2__current = new WaitForSeconds(AudioCrowdIntensity.sampleTime);
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

			public _updateCount_d__0(int __1__state)
			{
				this.__1__state = __1__state;
			}
		}

		private static readonly int maxColliders = 16;

		private static readonly float sampleTime = 3f;

		public string EventName;

		public string ParticipantCountRTP;

		private int layerMask;

		private int count;

		private Vector3 spherePos;

		private float sphereRadius;

		private Collider[] colliders = new Collider[AudioCrowdIntensity.maxColliders];

		public void Awake()
		{
			SphereCollider component = base.GetComponent<SphereCollider>();
			this.spherePos = base.transform.position + component.center;
			this.sphereRadius = component.radius;
			this.count = 0;
			this.layerMask = LayerConstants.GetAllPlayersLayerCollisionMask();
			CoroutineRunner.Start(this.updateCount(), this, "ObjectiveListener");
		}

		private IEnumerator updateCount()
		{
			AudioCrowdIntensity._updateCount_d__0 _updateCount_d__ = new AudioCrowdIntensity._updateCount_d__0(0);
			_updateCount_d__.__4__this = this;
			return _updateCount_d__;
		}
	}
}