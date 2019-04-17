using ClubPenguin.Core;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;
using UnityEngine;

namespace ClubPenguin.BlobShadows
{
	public class BlobShadowCaster : MonoBehaviour
	{
		private const float AVATAR_BLOB_SHADOW_SCALE = 0.6f;

		public float ScaleX = 1f;

		public float ScaleZ = 1f;

		[HideInInspector]
		public bool GeoVisible = false;

		private BlobShadowRenderer blobShadowRenderer;

		private EventDispatcher eventDispatcher;

		public bool ShadowCamVisible
		{
			get
			{
				return !(this.blobShadowRenderer != null) || this.blobShadowRenderer.IsShadowsVisible;
			}
		}

		private void Awake()
		{
			this.eventDispatcher = Service.Get<EventDispatcher>();
		}

		public void Start()
		{
			if (SceneRefs.IsSet<BlobShadowRenderer>())
			{
				this.blobShadowRenderer = SceneRefs.Get<BlobShadowRenderer>();
				this.SetIsActive(this.blobShadowRenderer.IsShadowsVisible);
			}
			this.eventDispatcher.AddListener<BlobShadowEvents.DisableBlobShadows>(new EventHandlerDelegate<BlobShadowEvents.DisableBlobShadows>(this.onDisableBlobShadows), EventDispatcher.Priority.DEFAULT);
			this.eventDispatcher.AddListener<BlobShadowEvents.EnableBlobShadows>(new EventHandlerDelegate<BlobShadowEvents.EnableBlobShadows>(this.onEnableBlobShadows), EventDispatcher.Priority.DEFAULT);
			this.ScaleX = 0.6f;
			this.ScaleZ = 0.6f;
		}

		public void OnDestroy()
		{
			this.eventDispatcher.RemoveListener<BlobShadowEvents.DisableBlobShadows>(new EventHandlerDelegate<BlobShadowEvents.DisableBlobShadows>(this.onDisableBlobShadows));
			this.eventDispatcher.RemoveListener<BlobShadowEvents.EnableBlobShadows>(new EventHandlerDelegate<BlobShadowEvents.EnableBlobShadows>(this.onEnableBlobShadows));
			if (this.blobShadowRenderer != null)
			{
				this.blobShadowRenderer.ShadowCasters.Remove(this);
			}
			this.GeoVisible = false;
		}

		public void SetIsActiveIfVisible()
		{
			this.SetIsActive(this.ShadowCamVisible);
		}

		public void SetIsActive(bool isActive)
		{
			if (this.blobShadowRenderer != null)
			{
				if (isActive)
				{
					if (!this.blobShadowRenderer.ShadowCasters.Contains(this))
					{
						this.blobShadowRenderer.ShadowCasters.Add(this);
					}
				}
			}
			this.GeoVisible = isActive;
		}

		internal void SetBlobShadowCam(BlobShadowRenderer blobShadowCam)
		{
			if (!(base.gameObject == null))
			{
				this.blobShadowRenderer = blobShadowCam;
				this.SetIsActive(blobShadowCam.IsShadowsVisible);
			}
		}

		private void Update()
		{
			if (!this.GeoVisible && this.blobShadowRenderer != null)
			{
				if (!this.blobShadowRenderer.ShadowCasters.Contains(this))
				{
					this.blobShadowRenderer.ShadowCasters.Add(this);
					this.SetIsActiveIfVisible();
				}
			}
		}

		private bool onEnableBlobShadows(BlobShadowEvents.EnableBlobShadows evt)
		{
			this.SetIsActive(true);
			return false;
		}

		private bool onDisableBlobShadows(BlobShadowEvents.DisableBlobShadows evt)
		{
			bool result;
			if (!evt.IncludeLocalPlayerShadow && base.CompareTag("Player"))
			{
				result = false;
			}
			else
			{
				this.SetIsActive(false);
				result = false;
			}
			return result;
		}
	}
}