using Fabric;
using System;
using UnityEngine;

namespace ClubPenguin.Audio
{
	internal class AudioEffects : MonoBehaviour
	{
		[Serializable]
		public struct OnCollisionEntry
		{
			public string EventName;

			public float MinRelativeVelocity;

			public float MaxRelativeVelocity;
		}

		public AudioEffects.OnCollisionEntry[] OnCollision = new AudioEffects.OnCollisionEntry[0];

		private float minRelativeVelSq;

		public void OnCollisionEnter(Collision collision)
		{
			float sqrMagnitude = collision.relativeVelocity.sqrMagnitude;
			for (int i = 0; i < this.OnCollision.Length; i++)
			{
				if (sqrMagnitude >= this.OnCollision[i].MinRelativeVelocity * this.OnCollision[i].MinRelativeVelocity && sqrMagnitude < this.OnCollision[i].MaxRelativeVelocity * this.OnCollision[i].MaxRelativeVelocity)
				{
					EventManager.Instance.PostEvent(this.OnCollision[i].EventName, EventAction.PlaySound, base.gameObject);
					break;
				}
			}
		}
	}
}