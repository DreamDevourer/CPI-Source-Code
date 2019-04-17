// IMinigameService
using ClubPenguin.Net;
using ClubPenguin.Net.Domain;

public interface IMinigameService : INetworkService
{
	void CastFishingRod(ICastFishingRodErrorHandler errorHandler);

	void CatchFish(SignedResponse<FishingResult> fish, string winningRewardName);
}
