using Disney.Kelowna.Common;
using Disney.MobileNetwork;
using Foundation.Unity;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	public class AvatarViewCombined : AvatarView
	{
		public int MaxAtlasDimension = 512;

		public bool UseGpuSkinning;

		private AvatarService avatarService;

		private AvatarService.Request combineRequest;

		private OutfitService.Request<EquipmentViewDefinition> partsRequest;

		private OutfitService.Request<Texture2D> decalsRequest;

		private readonly List<ViewPart> partViews = new List<ViewPart>();

		private Renderer rend;

		private bool modelDirty;

		private MeshDefinition meshDef;

		protected override void onAwake()
		{
			this.avatarService = Service.Get<AvatarService>();
			Rig component = base.GetComponent<Rig>();
			SkinnedMeshDefinition skinnedMeshDefinition = new SkinnedMeshDefinition(this.UseGpuSkinning);
			skinnedMeshDefinition.RootBoneName = component.RootBone.name;
			skinnedMeshDefinition.BoneNames = new string[component.Bones.Length];
			for (int i = 0; i < component.Bones.Length; i++)
			{
				skinnedMeshDefinition.BoneNames[i] = component.Bones[i].name;
			}
			this.meshDef = skinnedMeshDefinition;
			this.rend = this.meshDef.CreateRenderer(base.gameObject);
			this.Model.Definition.RenderProperties.Apply(this.rend);
		}

		public override Bounds GetBounds()
		{
			return (this.rend != null) ? this.rend.bounds : default(Bounds);
		}

		public void OnEnable()
		{
			this.Model.ColorChanged += new Action(this.model_ColorChanged);
			this.Model.PartChanged += new Action<int, int, AvatarModel.Part, AvatarModel.Part>(this.model_PartChanged);
			this.Model.OutfitSet += new Action<IEnumerable<AvatarModel.ApplyResult>>(this.model_OutfitSet);
		}

		public void OnDisable()
		{
			this.Model.ColorChanged -= new Action(this.model_ColorChanged);
			this.Model.PartChanged -= new Action<int, int, AvatarModel.Part, AvatarModel.Part>(this.model_PartChanged);
			this.Model.OutfitSet -= new Action<IEnumerable<AvatarModel.ApplyResult>>(this.model_OutfitSet);
		}

		public void LateUpdate()
		{
			if (this.modelDirty && !base.IsBusy)
			{
				this.modelDirty = false;
				base.startWork();
				this.cleanup();
				this.partViews.Clear();
				List<KeyValuePair<TypedAssetContentKey<Texture2D>, Action<Texture2D>>> list = new List<KeyValuePair<TypedAssetContentKey<Texture2D>, Action<Texture2D>>>();
				List<KeyValuePair<TypedAssetContentKey<EquipmentViewDefinition>, Action<EquipmentViewDefinition>>> list2 = new List<KeyValuePair<TypedAssetContentKey<EquipmentViewDefinition>, Action<EquipmentViewDefinition>>>();
				foreach (AvatarModel.Part current in this.Model.IterateParts())
				{
					ViewPart viewPart = new ViewPart();
					if (current.Equipment != null)
					{
						EquipmentModelDefinition.Part eqPart = current.Equipment.Parts[current.Index];
						list2.Add(AvatarView.CreatePartContent(this.Model, viewPart, current, eqPart));
						if (current.Decals != null)
						{
							AvatarView.CreateDecalContent(viewPart, current, list);
						}
					}
					else
					{
						BodyViewDefinition bodyViewDefinition = this.Model.Definition.Slots[current.Index].LOD[this.Model.LodLevel];
						bodyViewDefinition.ApplyToViewPart(viewPart);
					}
					this.partViews.Add(viewPart);
				}
				this.partsRequest = this.outfitService.Load<EquipmentViewDefinition>(list2, this.outfitService.EquipmentPartCache, null);
				this.decalsRequest = this.outfitService.Load<Texture2D>(list, this.outfitService.DecalCache, null);
			}
		}

		public void Update()
		{
			if (this.combineRequest == null)
			{
				if (this.partsRequest != null && this.partsRequest.Finished && this.decalsRequest != null && this.decalsRequest.Finished)
				{
					BodyColorMaterialProperties bodycolor = new BodyColorMaterialProperties(this.Model.BeakColor, this.Model.BellyColor, this.Model.BodyColor);
					this.combineRequest = this.avatarService.CombineParts(this.Model.Definition, bodycolor, this.partViews, this.MaxAtlasDimension);
				}
			}
			else if (this.combineRequest.Finished)
			{
				this.setupRenderer();
				this.outfitService.Unload<EquipmentViewDefinition>(this.partsRequest);
				this.partsRequest = null;
				this.outfitService.Unload<Texture2D>(this.decalsRequest);
				this.decalsRequest = null;
				this.combineRequest = null;
				base.stopWork();
			}
		}

		private void setupRenderer()
		{
			ComponentExtensions.DestroyIfInstance(this.rend.sharedMaterial);
			this.rend.sharedMaterial = this.meshDef.CreateCombinedMaterial(this.combineRequest.Atlas);
			this.meshDef.ApplyMesh(base.gameObject, this.combineRequest.Mesh);
			this.rend.enabled = true;
		}

		protected override void cleanup()
		{
			this.meshDef.CleanUp(base.gameObject);
			ComponentExtensions.DestroyIfInstance(this.rend.sharedMaterial);
			this.rend.enabled = false;
			if (this.partsRequest != null)
			{
				this.outfitService.Unload<EquipmentViewDefinition>(this.partsRequest);
				this.partsRequest = null;
			}
			if (this.decalsRequest != null)
			{
				this.outfitService.Unload<Texture2D>(this.decalsRequest);
				this.decalsRequest = null;
			}
			this.combineRequest = null;
		}

		private void model_ColorChanged()
		{
			this.modelDirty = true;
		}

		private void model_OutfitSet(IEnumerable<AvatarModel.ApplyResult> results)
		{
			this.modelDirty = true;
		}

		private void model_PartChanged(int arg1, int arg2, AvatarModel.Part arg3, AvatarModel.Part arg4)
		{
			this.modelDirty = true;
		}
	}
}