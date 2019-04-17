using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	public class AvatarDefinition : ScriptableObject
	{
		public const string DEFINITION_NAME_PATTERN = "{0}_{1}_{2}_{3}LOD";

		public static readonly AssetContentKey DEFINITION_KEYPATTERN = new AssetContentKey("definitions/equipment/*");

		public static readonly string[] PartTypeStrings = new string[]
		{
			"rep",
			"add",
			"sec"
		};

		public readonly Dictionary<string, int> EquipmentIndexLookup = new Dictionary<string, int>();

		public readonly Dictionary<string, int> SlotIndexLookup = new Dictionary<string, int>();

		public readonly Dictionary<string, int> BoneIndexLookup = new Dictionary<string, int>();

		public AvatarSlot[] Slots = new AvatarSlot[0];

		public EquipmentList EquipmentList;

		public RigDefinition RigDefinition;

		public string[] BoneNames = new string[0];

		public Matrix4x4[] BindPose;

		public BodyColorMaterialProperties BodyColor;

		public Avatar UnityAvatar;

		public RendererProperties RenderProperties;

		public EquipmentModelDefinition GetEquipmentDefinition(DCustomEquipment customEq)
		{
			return this.GetEquipmentDefinition(customEq.Name);
		}

		public EquipmentModelDefinition GetEquipmentDefinition(string customEqName)
		{
			int num;
			EquipmentModelDefinition result;
			if (this.EquipmentIndexLookup.TryGetValue(customEqName.ToLower(), out num))
			{
				result = this.EquipmentList.Equipment[num];
			}
			else
			{
				Log.LogError(this, "Could not find equipment definition for " + customEqName);
				result = null;
			}
			return result;
		}

		public void OnEnable()
		{
			this.UpdateLookups();
		}

		public void UpdateLookups()
		{
			this.EquipmentIndexLookup.Clear();
			if (this.EquipmentList != null)
			{
				for (int i = 0; i < this.EquipmentList.Equipment.Length; i++)
				{
					this.EquipmentIndexLookup[this.EquipmentList.Equipment[i].Name.ToLower()] = i;
				}
			}
			this.SlotIndexLookup.Clear();
			for (int i = 0; i < this.Slots.Length; i++)
			{
				this.SlotIndexLookup[this.Slots[i].Name] = i;
			}
			this.BoneIndexLookup.Clear();
			for (int i = 0; i < this.BoneNames.Length; i++)
			{
				this.BoneIndexLookup[this.BoneNames[i]] = i;
			}
		}

		public TypedAssetContentKey<EquipmentViewDefinition> CreatePartKey(EquipmentModelDefinition equipment, EquipmentModelDefinition.Part eqPart, int lodLevel)
		{
			string text = string.Format("{0}_{1}_{2}_{3}LOD", new object[]
			{
				equipment.Name,
				AvatarDefinition.PartTypeStrings[(int)eqPart.PartType],
				this.Slots[eqPart.SlotIndex].Name,
				lodLevel
			});
			return new TypedAssetContentKey<EquipmentViewDefinition>(AvatarDefinition.DEFINITION_KEYPATTERN, new string[]
			{
				text
			});
		}
	}
}