// TagDefinitionKey
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using System;

[Serializable]
public class TagDefinitionKey : TypedStaticGameDataKey<TagDefinition, string>
{
	public TagDefinitionKey(string id)
	{
		Id = id;
	}
}
