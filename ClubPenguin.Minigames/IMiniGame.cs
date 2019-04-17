// IMiniGame
using ClubPenguin.Net.Domain;

public interface IMiniGame
{
	SignedResponse<FishingResult> GetSignedResponse();
}
