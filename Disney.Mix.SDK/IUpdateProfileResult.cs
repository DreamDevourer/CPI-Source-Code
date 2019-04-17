// IUpdateProfileResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public interface IUpdateProfileResult
{
	bool Success
	{
		get;
	}

	IEnumerable<IInvalidProfileItemError> Errors
	{
		get;
	}
}
