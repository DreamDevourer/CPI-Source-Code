// MusicGenreDefinitionDefinitionKey
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using System;

[Serializable]
public class MusicGenreDefinitionDefinitionKey : TypedStaticGameDataKey<MusicGenreDefinition, int>
{
	public MusicGenreDefinitionDefinitionKey(int id)
	{
		Id = id;
	}
}
