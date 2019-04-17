// InvalidLastNameError
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class InvalidLastNameError : AbstractInvalidProfileItemError, IInvalidLastNameError, IInvalidProfileItemError
{
	public InvalidLastNameError(string description)
		: base(description)
	{
	}
}
