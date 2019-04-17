// ValidateDisplayNameFailedModerationResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public class ValidateDisplayNameFailedModerationResult : IValidateDisplayNameFailedModerationResult, IValidateDisplayNameResult
{
	public bool Success
	{
		get;
		private set;
	}

	public IEnumerable<string> SuggestedDisplayNames
	{
		get;
		private set;
	}

	public ValidateDisplayNameFailedModerationResult(bool success)
	{
		Success = success;
		SuggestedDisplayNames = new List<string>();
	}
}
