// EquipmentCategoryDefinition
using ClubPenguin.Core.StaticGameData;
using DevonLocalization.Core;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/Catalog/EquipmentCategory")]
public class EquipmentCategoryDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public int Id;

	[LocalizationToken]
	public string DisplayName;

	public string EquipAnimationTrigger;
}
