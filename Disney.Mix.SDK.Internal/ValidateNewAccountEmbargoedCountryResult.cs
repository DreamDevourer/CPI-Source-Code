// ValidateNewAccountEmbargoedCountryResult
using Disney.Mix.SDK;
using System.Collections.Generic;
using System.Linq;

public class ValidateNewAccountEmbargoedCountryResult : IValidateNewAccountEmbargoedCountryResult, IValidateNewAccountResult
{
	public bool Success => false;

	public IEnumerable<IValidateNewAccountError> Errors
	{
		get;
		private set;
	}

	public ValidateNewAccountEmbargoedCountryResult()
	{
		Errors = Enumerable.Empty<IValidateNewAccountError>();
	}
}
