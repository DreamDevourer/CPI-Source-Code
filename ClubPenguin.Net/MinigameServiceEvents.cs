// MinigameServiceEvents
using ClubPenguin.Net.Domain;

public static class MinigameServiceEvents
{
	public struct FishingResultRecieved
	{
		public SignedResponse<FishingResult> Result;

		public FishingResultRecieved(SignedResponse<FishingResult> result)
		{
			Result = result;
		}
	}
}
