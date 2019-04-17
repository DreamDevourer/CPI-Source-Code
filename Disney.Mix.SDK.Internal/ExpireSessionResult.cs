// ExpireSessionResult
using Disney.Mix.SDK;

public class ExpireSessionResult : IExpireSessionResult
{
	public bool Success
	{
		get;
		private set;
	}

	public ExpireSessionResult(bool success)
	{
		Success = success;
	}
}
