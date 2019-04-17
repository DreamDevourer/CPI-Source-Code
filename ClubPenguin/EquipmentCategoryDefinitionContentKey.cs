// EquipmentCategoryDefinitionContentKey
using ClubPenguin;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class EquipmentCategoryDefinitionContentKey : TypedAssetContentKey<EquipmentCategoryDefinition>
{
	public EquipmentCategoryDefinitionContentKey(string key)
		: base(key)
	{
	}
}
