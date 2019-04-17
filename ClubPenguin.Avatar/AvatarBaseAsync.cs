using System;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	public abstract class AvatarBaseAsync : MonoBehaviour
	{
		public event Action<AvatarBaseAsync> OnBusy;

		public event Action<AvatarBaseAsync> OnReady;

		public bool IsReady
		{
			get;
			private set;
		}

		public bool IsBusy
		{
			get;
			private set;
		}

		protected void startWork()
		{
			this.IsReady = false;
			this.IsBusy = true;
			if (this.OnBusy != null)
			{
				this.OnBusy(this);
			}
		}

		protected void stopWork()
		{
			this.IsReady = true;
			this.IsBusy = false;
			if (this.OnReady != null)
			{
				this.OnReady(this);
			}
		}
	}
}