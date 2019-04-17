// ValidateDisplayNameExistsResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public class ValidateDisplayNameExistsResult : IValidateDisplayNameExistsResult, IValidateDisplayNameResult
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

	public ValidateDisplayNameExistsResult(bool success)
	{
		Success = success;
		SuggestedDisplayNames = new List<string>();
	}

	public ValidateDisplayNameExistsResult(bool success, IEnumerable<string> suggestions)
	{
		Success = success;
		SuggestedDisplayNames = suggestions;
	}
}
