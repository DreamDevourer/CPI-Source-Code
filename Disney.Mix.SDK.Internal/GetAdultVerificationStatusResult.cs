// GetAdultVerificationStatusResult
using Disney.Mix.SDK;

public class GetAdultVerificationStatusResult : IGetAdultVerificationStatusResult
{
	public bool Success
	{
		get;
		private set;
	}

	public bool VerifiedAsAdult
	{
		get;
		private set;
	}

	public bool MaxAttempts
	{
		get;
		private set;
	}

	public GetAdultVerificationStatusResult(bool success, bool verifiedAsAdult, bool maxAttempts)
	{
		Success = success;
		VerifiedAsAdult = verifiedAsAdult;
		MaxAttempts = maxAttempts;
	}
}
