// VerifyAdultFailedInvalidDataResult
using Disney.Mix.SDK;

public class VerifyAdultFailedInvalidDataResult : IVerifyAdultFailedInvalidDataResult, IVerifyAdultResult
{
	public bool Success => false;

	public bool MaxAttempts => false;
}
