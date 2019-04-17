// VerifyAdultFailedMissingInfoResult
using Disney.Mix.SDK;

public class VerifyAdultFailedMissingInfoResult : IVerifyAdultFailedMissingInfoResult, IVerifyAdultResult
{
	public bool Success => false;

	public bool MaxAttempts => false;
}
