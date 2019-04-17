// SetLangaugePreferenceResult
using Disney.Mix.SDK;

public class SetLangaugePreferenceResult : ISetLangaugePreferenceResult
{
	public bool Success
	{
		get;
		private set;
	}

	public SetLangaugePreferenceResult(bool success)
	{
		Success = success;
	}
}
