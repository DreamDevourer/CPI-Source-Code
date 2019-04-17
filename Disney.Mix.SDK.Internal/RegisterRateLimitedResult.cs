// RegisterRateLimitedResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public class RegisterRateLimitedResult : IRegisterRateLimitedResult, IRegisterResult
{
	public bool Success => false;

	public ISession Session => null;

	public IEnumerable<IInvalidProfileItemError> Errors
	{
		get;
		private set;
	}

	public RegisterRateLimitedResult()
	{
		Errors = new IInvalidProfileItemError[0];
	}
}
