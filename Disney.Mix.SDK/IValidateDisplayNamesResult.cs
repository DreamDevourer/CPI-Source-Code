// IValidateDisplayNamesResult
using System.Collections.Generic;

public interface IValidateDisplayNamesResult
{
	bool Success
	{
		get;
	}

	IEnumerable<string> DisplayNames
	{
		get;
	}
}
