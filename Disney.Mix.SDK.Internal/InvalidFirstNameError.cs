// InvalidFirstNameError
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class InvalidFirstNameError : AbstractInvalidProfileItemError, IInvalidFirstNameError, IInvalidProfileItemError
{
	public InvalidFirstNameError(string description)
		: base(description)
	{
	}
}
