// StaticGameDataDefinitionKey
using ClubPenguin.Core.StaticGameData;
using System;

[Serializable]
public class StaticGameDataDefinitionKey : TypedStaticGameDataKey<StaticGameDataDefinition, string>
{
	public StaticGameDataDefinitionKey(string id)
	{
		Id = id;
	}
}
