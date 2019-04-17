// IValidateDisplayNameResult
using System.Collections.Generic;

public interface IValidateDisplayNameResult
{
	bool Success
	{
		get;
	}

	IEnumerable<string> SuggestedDisplayNames
	{
		get;
	}
}
