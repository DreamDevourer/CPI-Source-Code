// PlayerRoomData
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct PlayerRoomData
{
	public PlayerOutfitDetails outfit;

	public QuestStateCollection quests;

	public ConsumableInventory consumableInventory;

	public PlayerAssets assets;

	public TaskProgressList dailyTaskProgress;

	public Profile profile;

	public bool member;
}
