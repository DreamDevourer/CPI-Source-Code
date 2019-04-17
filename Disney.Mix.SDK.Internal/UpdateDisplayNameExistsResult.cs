// UpdateDisplayNameExistsResult
using Disney.Mix.SDK;

public class UpdateDisplayNameExistsResult : IUpdateDisplayNameExistsResult, IUpdateDisplayNameResult
{
	public bool Success
	{
		get;
		private set;
	}

	public UpdateDisplayNameExistsResult(bool success)
	{
		Success = success;
	}
}
