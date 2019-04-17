// ZonePathingNode
using ClubPenguin;
using System;

[Serializable]
public struct ZonePathingNode
{
	public ZoneDefinition Zone;

	public ZoneDefinition[] ZoneTransitions;
}
