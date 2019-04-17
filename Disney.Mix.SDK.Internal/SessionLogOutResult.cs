// SessionLogOutResult
using Disney.Mix.SDK;

internal class SessionLogOutResult : ISessionLogOutResult
{
	public bool Success
	{
		get;
		private set;
	}

	public SessionLogOutResult(bool success)
	{
		Success = success;
	}
}
