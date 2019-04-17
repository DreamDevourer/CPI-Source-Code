// FishingCatchRequest
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct FishingCatchRequest
{
	public SignedResponse<FishingResult> fishingCastResult;

	public string winningRewardName;

	public FishingCatchRequest(SignedResponse<FishingResult> fishingCastResult, string winningRewardName)
	{
		this.fishingCastResult = fishingCastResult;
		this.winningRewardName = winningRewardName;
	}
}
