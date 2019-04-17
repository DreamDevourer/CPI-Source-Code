// IRewardService
using ClubPenguin.Net;
using ClubPenguin.Net.Domain;

public interface IRewardService : INetworkService
{
	void ExchangeAllForCoins();

	void CalculateExchangeAllForCoins(IBaseNetworkErrorHandler errorHandler);

	void ClaimPreregistrationRewards();

	void ClaimReward(int rewardId);

	void ClaimServerAddedRewards();

	void ClaimQuickNotificationReward();

	void ClaimDailySpinReward();

	void QA_SetReward(Reward reward);
}
