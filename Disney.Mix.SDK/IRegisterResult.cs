// IRegisterResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public interface IRegisterResult
{
	bool Success
	{
		get;
	}

	ISession Session
	{
		get;
	}

	IEnumerable<IInvalidProfileItemError> Errors
	{
		get;
	}
}
