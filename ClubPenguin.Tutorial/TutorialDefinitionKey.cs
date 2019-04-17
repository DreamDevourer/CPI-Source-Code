// TutorialDefinitionKey
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.Tutorial;
using System;

[Serializable]
public class TutorialDefinitionKey : TypedStaticGameDataKey<TutorialDefinition, int>
{
	public TutorialDefinitionKey(int id)
	{
		Id = id;
	}
}
