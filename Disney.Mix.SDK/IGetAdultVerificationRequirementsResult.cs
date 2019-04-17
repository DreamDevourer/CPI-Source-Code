// IGetAdultVerificationRequirementsResult
public interface IGetAdultVerificationRequirementsResult
{
	bool Success
	{
		get;
	}

	bool IsRequired
	{
		get;
	}

	bool IsAvailable
	{
		get;
	}
}
