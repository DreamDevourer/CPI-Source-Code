// RegisterEmbargoedCountryResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public class RegisterEmbargoedCountryResult : IRegisterEmbargoedCountryResult, IRegisterResult
{
	public bool Success => false;

	public ISession Session => null;

	public IEnumerable<IInvalidProfileItemError> Errors
	{
		get;
		private set;
	}

	public RegisterEmbargoedCountryResult()
	{
		Errors = new IInvalidProfileItemError[0];
	}
}
