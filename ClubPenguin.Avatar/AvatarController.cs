using System;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[DisallowMultipleComponent]
	public class AvatarController : MonoBehaviour
	{
		public AvatarModel Model;

		public virtual void Awake()
		{
			if (this.Model == null)
			{
				this.Model = base.GetComponent<AvatarModel>();
			}
		}
	}
}