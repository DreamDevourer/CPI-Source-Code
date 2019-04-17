// RegisterResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public class RegisterResult : IRegisterResult
{
	public bool Success
	{
		get;
		private set;
	}

	public ISession Session
	{
		get;
		private set;
	}

	public IEnumerable<IInvalidProfileItemError> Errors
	{
		get;
		private set;
	}

	public RegisterResult(bool success, ISession session, IEnumerable<IInvalidProfileItemError> errors)
	{
		Success = success;
		Session = session;
		Errors = errors;
	}
}
