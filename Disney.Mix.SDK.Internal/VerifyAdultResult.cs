// VerifyAdultResult
using Disney.Mix.SDK;

public class VerifyAdultResult : IVerifyAdultResult
{
	public bool Success
	{
		get;
		private set;
	}

	public bool MaxAttempts
	{
		get;
		private set;
	}

	public VerifyAdultResult(bool success, bool maxAttempts)
	{
		Success = success;
		MaxAttempts = maxAttempts;
	}
}
