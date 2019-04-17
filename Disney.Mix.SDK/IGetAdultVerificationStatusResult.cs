// IGetAdultVerificationStatusResult
public interface IGetAdultVerificationStatusResult
{
	bool Success
	{
		get;
	}

	bool VerifiedAsAdult
	{
		get;
	}

	bool MaxAttempts
	{
		get;
	}
}
