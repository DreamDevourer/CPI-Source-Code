// UpdateDisplayNameResult
using Disney.Mix.SDK;

public class UpdateDisplayNameResult : IUpdateDisplayNameResult
{
	public bool Success
	{
		get;
		private set;
	}

	public UpdateDisplayNameResult(bool success)
	{
		Success = success;
	}
}
