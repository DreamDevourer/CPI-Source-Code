// ValidateNewAccountGatedLocationResult
using Disney.Mix.SDK;
using System.Collections.Generic;
using System.Linq;

public class ValidateNewAccountGatedLocationResult : IValidateNewAccountGatedLocationResult, IValidateNewAccountResult
{
	public bool Success => false;

	public IEnumerable<IValidateNewAccountError> Errors
	{
		get;
		private set;
	}

	public ValidateNewAccountGatedLocationResult()
	{
		Errors = Enumerable.Empty<IValidateNewAccountError>();
	}
}
