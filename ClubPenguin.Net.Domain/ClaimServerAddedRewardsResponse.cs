// ClaimServerAddedRewardsResponse
using ClubPenguin.Net.Domain;
using System.Collections.Generic;

public class ClaimServerAddedRewardsResponse : CPResponse
{
	public List<ClaimedServerAddedReward> claimedRewards;
}
