// UntrustResult
using Disney.Mix.SDK;

internal class UntrustResult : IUntrustResult
{
	public bool Success
	{
		get;
		private set;
	}

	public UntrustResult(bool success)
	{
		Success = success;
	}
}
