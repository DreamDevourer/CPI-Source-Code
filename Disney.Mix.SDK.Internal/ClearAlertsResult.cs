// ClearAlertsResult
using Disney.Mix.SDK;

public class ClearAlertsResult : IClearAlertsResult
{
	public bool Success
	{
		get;
		private set;
	}

	public ClearAlertsResult(bool success)
	{
		Success = success;
	}
}
