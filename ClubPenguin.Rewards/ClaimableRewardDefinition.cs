// ClaimableRewardDefinition
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using DevonLocalization.Core;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/ClaimedReward")]
public class ClaimableRewardDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public int Id;

	[LocalizationToken]
	public string TitleToken;

	public bool IsMemberOnly;

	public bool ClaimOnLogin = true;

	public RewardDefinition Reward;

	public ScheduledEventDateDefinitionKey DateDefinitionKey;
}
