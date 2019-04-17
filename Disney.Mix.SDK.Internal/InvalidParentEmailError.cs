// InvalidParentEmailError
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class InvalidParentEmailError : AbstractInvalidProfileItemError, IInvalidParentEmailError, IInvalidProfileItemError
{
	public InvalidParentEmailError(string description)
		: base(description)
	{
	}
}
