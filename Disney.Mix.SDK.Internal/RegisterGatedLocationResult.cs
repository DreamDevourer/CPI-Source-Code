// RegisterGatedLocationResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public class RegisterGatedLocationResult : IRegisterGatedLocationResult, IRegisterResult
{
	public bool Success => false;

	public ISession Session => null;

	public IEnumerable<IInvalidProfileItemError> Errors
	{
		get;
		private set;
	}

	public RegisterGatedLocationResult()
	{
		Errors = new IInvalidProfileItemError[0];
	}
}
