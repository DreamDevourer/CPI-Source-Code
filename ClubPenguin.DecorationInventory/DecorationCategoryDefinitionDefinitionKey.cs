// DecorationCategoryDefinitionDefinitionKey
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.DecorationInventory;
using System;

[Serializable]
public class DecorationCategoryDefinitionDefinitionKey : TypedStaticGameDataKey<DecorationCategoryDefinition, int>
{
	public DecorationCategoryDefinitionDefinitionKey(int id)
	{
		Id = id;
	}
}
