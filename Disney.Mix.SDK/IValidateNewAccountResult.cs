// IValidateNewAccountResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public interface IValidateNewAccountResult
{
	bool Success
	{
		get;
	}

	IEnumerable<IValidateNewAccountError> Errors
	{
		get;
	}
}
