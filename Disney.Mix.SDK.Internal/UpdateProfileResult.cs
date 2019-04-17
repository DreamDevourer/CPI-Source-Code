// UpdateProfileResult
using Disney.Mix.SDK;
using System.Collections.Generic;

internal class UpdateProfileResult : IUpdateProfileResult
{
	public bool Success
	{
		get;
		private set;
	}

	public IEnumerable<IInvalidProfileItemError> Errors
	{
		get;
		private set;
	}

	public UpdateProfileResult(bool success, IEnumerable<IInvalidProfileItemError> errors)
	{
		Success = success;
		Errors = errors;
	}
}
