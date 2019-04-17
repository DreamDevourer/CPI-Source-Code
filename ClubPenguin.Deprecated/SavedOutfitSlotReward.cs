// SavedOutfitSlotReward
using ClubPenguin.Depercated;
using ClubPenguin.Net.Domain;
using LitJson;
using System;

[Serializable]
public class SavedOutfitSlotReward : IRewardable
{
	private int slotCount;

	public object Reward => slotCount;

	public string RewardType => "savedOutfitSlots";

	public SavedOutfitSlotReward()
	{
		slotCount = 0;
	}

	public SavedOutfitSlotReward(int count)
	{
		slotCount = count;
	}

	public void Add(IRewardable reward)
	{
		slotCount = ((SavedOutfitSlotReward)reward).slotCount;
	}

	public void FromJson(JsonData jsonData)
	{
		slotCount = (int)jsonData;
	}

	public bool IsEmpty()
	{
		return slotCount == 0;
	}
}
