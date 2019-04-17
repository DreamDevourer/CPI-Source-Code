// LootTableBucketDefinition
using ClubPenguin.Core.StaticGameData;
using System;

[Serializable]
public class LootTableBucketDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public string BucketName;

	public int Weight;
}
