// ClaimableRewardData
using ClubPenguin.Net.Offline;
using System.Collections.Generic;

public struct ClaimableRewardData : IOfflineData
{
	public List<int> ClimedRewards;

	public void Init()
	{
		ClimedRewards = new List<int>();
	}
}
