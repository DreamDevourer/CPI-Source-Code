// InvalidDisplayNameError
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class InvalidDisplayNameError : AbstractInvalidProfileItemError, IInvalidDisplayNameError, IInvalidProfileItemError
{
	public InvalidDisplayNameError(string description)
		: base(description)
	{
	}
}
