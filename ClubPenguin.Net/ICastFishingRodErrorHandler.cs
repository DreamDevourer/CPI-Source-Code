// ICastFishingRodErrorHandler
using ClubPenguin.Net;

public interface ICastFishingRodErrorHandler : IBaseNetworkErrorHandler
{
	void onBadFishingState();
}
