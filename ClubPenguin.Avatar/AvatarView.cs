using Disney.Kelowna.Common;
using Disney.MobileNetwork;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[DisallowMultipleComponent, RequireComponent(typeof(Animator))]
	public abstract class AvatarView : AvatarBaseAsync
	{
		private sealed class __c__DisplayClass1
		{
			public ViewPart partView;

			public void _CreatePartContent_b__0(EquipmentViewDefinition eq)
			{
				AvatarView.onPartDefinitionLoaded(this.partView, eq);
			}
		}

		private sealed class __c__DisplayClass4
		{
			public DecalMaterialProperties decalMatProp;

			public void _CreateDecalContent_b__3(Texture2D decalTex)
			{
				this.decalMatProp.Texture = decalTex;
			}
		}

		public static readonly AssetContentKey DECAL_KEYPATTERN = new AssetContentKey("decals/*");

		public AvatarModel Model;

		protected OutfitService outfitService;

		public abstract Bounds GetBounds();

		public void Awake()
		{
			this.outfitService = Service.Get<OutfitService>();
			if (this.Model == null)
			{
				this.Model = base.GetComponent<AvatarModel>();
			}
			Animator component = base.GetComponent<Animator>();
			component.avatar = this.Model.Definition.UnityAvatar;
			this.onAwake();
		}

		public void OnDestroy()
		{
			this.cleanup();
		}

		public static KeyValuePair<TypedAssetContentKey<EquipmentViewDefinition>, Action<EquipmentViewDefinition>> CreatePartContent(AvatarModel model, ViewPart partView, AvatarModel.Part modelPart, EquipmentModelDefinition.Part eqPart)
		{
			AvatarView.__c__DisplayClass1 __c__DisplayClass = new AvatarView.__c__DisplayClass1();
			__c__DisplayClass.partView = partView;
			TypedAssetContentKey<EquipmentViewDefinition> key = model.Definition.CreatePartKey(modelPart.Equipment, eqPart, model.LodLevel);
			return new KeyValuePair<TypedAssetContentKey<EquipmentViewDefinition>, Action<EquipmentViewDefinition>>(key, new Action<EquipmentViewDefinition>(__c__DisplayClass._CreatePartContent_b__0));
		}

		public static TypedAssetContentKey<Texture2D> CreateDecalKey(DCustomEquipmentDecal decal)
		{
			return new TypedAssetContentKey<Texture2D>(AvatarView.DECAL_KEYPATTERN, new string[]
			{
				decal.TextureName
			});
		}

		public static void CreateDecalContent(ViewPart partView, AvatarModel.Part modelPart, List<KeyValuePair<TypedAssetContentKey<Texture2D>, Action<Texture2D>>> decalContent)
		{
			partView.InitDecalProps(modelPart.Decals.Length);
			for (int i = 0; i < modelPart.Decals.Length; i++)
			{
				AvatarView.__c__DisplayClass4 __c__DisplayClass = new AvatarView.__c__DisplayClass4();
				DCustomEquipmentDecal decal = modelPart.Decals[i];
				__c__DisplayClass.decalMatProp = new DecalMaterialProperties(decal.Index);
				__c__DisplayClass.decalMatProp.Import(decal, null);
				partView.SetDecalProps(i, __c__DisplayClass.decalMatProp);
				TypedAssetContentKey<Texture2D> key = AvatarView.CreateDecalKey(decal);
				decalContent.Add(new KeyValuePair<TypedAssetContentKey<Texture2D>, Action<Texture2D>>(key, new Action<Texture2D>(__c__DisplayClass._CreateDecalContent_b__3)));
			}
		}

		private static void onPartDefinitionLoaded(ViewPart partView, EquipmentViewDefinition eq)
		{
			if (eq != null)
			{
				eq.ApplyToViewPart(partView);
			}
		}

		protected abstract void onAwake();

		protected abstract void cleanup();
	}
}