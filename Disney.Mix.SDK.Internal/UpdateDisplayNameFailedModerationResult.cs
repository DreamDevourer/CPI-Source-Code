// UpdateDisplayNameFailedModerationResult
using Disney.Mix.SDK;

public class UpdateDisplayNameFailedModerationResult : IUpdateDisplayNameFailedModerationResult, IUpdateDisplayNameResult
{
	public bool Success
	{
		get;
		private set;
	}

	public UpdateDisplayNameFailedModerationResult(bool success)
	{
		Success = success;
	}
}
