// WorldRoomPopulation
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class WorldRoomPopulation
{
	public readonly string worldName;

	public readonly RoomPopulationScale populationScaled;

	public WorldRoomPopulation()
	{
	}

	public WorldRoomPopulation(string worldName, RoomPopulationScale populationScaled)
	{
		this.worldName = worldName;
		this.populationScaled = populationScaled;
	}
}
