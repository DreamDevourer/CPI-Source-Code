// UnfriendResult
using Disney.Mix.SDK;

public class UnfriendResult : IUnfriendResult
{
	public bool Success
	{
		get;
		private set;
	}

	public UnfriendResult(bool success)
	{
		Success = success;
	}
}
