// QuestRewardsCollection
using ClubPenguin.Net.Domain;
using System.Collections.Generic;

public struct QuestRewardsCollection
{
	public Reward StartReward;

	public Reward CompleteReward;

	public Dictionary<string, Reward> ObjectiveRewards;
}
