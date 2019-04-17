using Disney.Kelowna.Common;
using Disney.MobileNetwork;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[DisallowMultipleComponent]
	public class AvatarViewDistinctChild : AvatarBaseAsync
	{
		private Renderer rend;

		private OutfitService outfitService;

		private readonly ViewPart partView = new ViewPart();

		private OutfitService.Request<EquipmentViewDefinition> currentEquipmentRequest;

		private OutfitService.Request<Texture2D> currentDecalRequest;

		private OutfitService.Request<EquipmentViewDefinition> loadingEquipmentRequest;

		private OutfitService.Request<Texture2D> loadingDecalRequest;

		private BodyColorMaterialProperties bodyMatProps;

		public int SlotIndex
		{
			get;
			internal set;
		}

		public int PartIndex
		{
			get;
			internal set;
		}

		public AvatarModel Model
		{
			get;
			internal set;
		}

		public Rig Rig
		{
			get;
			internal set;
		}

		public Renderer Renderer
		{
			get
			{
				return this.rend;
			}
		}

		public ViewPart ViewPart
		{
			get
			{
				return this.partView;
			}
		}

		public void Awake()
		{
			this.outfitService = Service.Get<OutfitService>();
		}

		public void OnEnable()
		{
			this.Model.ColorChanged += new Action(this.ApplyColor);
		}

		public void OnDisable()
		{
			this.Model.ColorChanged -= new Action(this.ApplyColor);
		}

		public void OnDestroy()
		{
			this.cleanupLoading();
			this.cleanupCurrent();
		}

		public void Apply(AvatarModel.Part newPart)
		{
			base.startWork();
			if (newPart != null)
			{
				if (newPart.Equipment != null)
				{
					this.cleanupLoading();
					EquipmentModelDefinition.Part eqPart = newPart.Equipment.Parts[newPart.Index];
					KeyValuePair<TypedAssetContentKey<EquipmentViewDefinition>, Action<EquipmentViewDefinition>>[] content = new KeyValuePair<TypedAssetContentKey<EquipmentViewDefinition>, Action<EquipmentViewDefinition>>[]
					{
						AvatarView.CreatePartContent(this.Model, this.partView, newPart, eqPart)
					};
					List<KeyValuePair<TypedAssetContentKey<Texture2D>, Action<Texture2D>>> list = new List<KeyValuePair<TypedAssetContentKey<Texture2D>, Action<Texture2D>>>();
					if (newPart.Decals != null)
					{
						AvatarView.CreateDecalContent(this.partView, newPart, list);
					}
					this.loadingEquipmentRequest = this.outfitService.Load<EquipmentViewDefinition>(content, this.outfitService.EquipmentPartCache, null);
					this.loadingDecalRequest = this.outfitService.Load<Texture2D>(list, this.outfitService.DecalCache, null);
				}
				else
				{
					this.cleanupCurrent();
					BodyViewDefinition bodyViewDefinition = this.Model.Definition.Slots[newPart.Index].LOD[this.Model.LodLevel];
					bodyViewDefinition.ApplyToViewPart(this.partView);
					this.setupRenderer();
					base.stopWork();
				}
				base.gameObject.SetActive(true);
			}
			else
			{
				base.gameObject.SetActive(false);
				this.cleanupCurrent();
				base.stopWork();
			}
		}

		public void ApplyColor()
		{
			this.bodyMatProps = new BodyColorMaterialProperties(this.Model.BeakColor, this.Model.BellyColor, this.Model.BodyColor);
		}

		public void Update()
		{
			if (base.IsBusy && this.loadingEquipmentRequest.Finished && this.loadingDecalRequest.Finished)
			{
				this.cleanupCurrent();
				this.switchLoadingRequestsToCurrent();
				this.setupRenderer();
				base.stopWork();
			}
			if (this.bodyMatProps != null)
			{
				if (this.rend != null)
				{
					Material sharedMaterial = this.rend.sharedMaterial;
					if (sharedMaterial != null)
					{
						this.bodyMatProps.Apply(sharedMaterial);
						this.bodyMatProps = null;
					}
				}
			}
		}

		private void setupRenderer()
		{
			this.partView.SetupRenderer(base.gameObject, this.Model, ref this.rend);
		}

		private void cleanupCurrent()
		{
			this.partView.CleanUp(base.gameObject);
			if (this.currentEquipmentRequest != null)
			{
				this.outfitService.Unload<EquipmentViewDefinition>(this.currentEquipmentRequest);
				this.currentEquipmentRequest = null;
			}
			if (this.currentDecalRequest != null)
			{
				this.outfitService.Unload<Texture2D>(this.currentDecalRequest);
				this.currentDecalRequest = null;
			}
		}

		private void cleanupLoading()
		{
			if (this.loadingEquipmentRequest != null)
			{
				this.outfitService.Unload<EquipmentViewDefinition>(this.loadingEquipmentRequest);
				this.loadingEquipmentRequest = null;
			}
			if (this.loadingDecalRequest != null)
			{
				this.outfitService.Unload<Texture2D>(this.loadingDecalRequest);
				this.loadingDecalRequest = null;
			}
		}

		private void switchLoadingRequestsToCurrent()
		{
			this.currentEquipmentRequest = this.loadingEquipmentRequest;
			this.currentDecalRequest = this.loadingDecalRequest;
			this.loadingEquipmentRequest = null;
			this.loadingDecalRequest = null;
		}
	}
}