// MiniGame
using ClubPenguin.MiniGames;
using ClubPenguin.Net.Domain;

public class MiniGame : IMiniGame
{
	private SignedResponse<FishingResult> response;

	public MiniGame(SignedResponse<FishingResult> signedResponse)
	{
		response = signedResponse;
	}

	public SignedResponse<FishingResult> GetSignedResponse()
	{
		return response;
	}
}
