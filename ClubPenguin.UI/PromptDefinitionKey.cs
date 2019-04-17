// PromptDefinitionKey
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.UI;
using System;

[Serializable]
public class PromptDefinitionKey : TypedStaticGameDataKey<PromptDefinition, string>
{
	public PromptDefinitionKey(string id)
	{
		Id = id;
	}
}
