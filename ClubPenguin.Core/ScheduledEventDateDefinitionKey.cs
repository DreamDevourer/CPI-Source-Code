// ScheduledEventDateDefinitionKey
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using System;

[Serializable]
public class ScheduledEventDateDefinitionKey : TypedStaticGameDataKey<ScheduledEventDateDefinition, int>
{
	public ScheduledEventDateDefinitionKey(int id)
	{
		Id = id;
	}
}
