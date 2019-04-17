// InvalidPasswordError
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class InvalidPasswordError : AbstractInvalidProfileItemError, IInvalidPasswordError, IInvalidProfileItemError
{
	public InvalidPasswordError(string description)
		: base(description)
	{
	}
}
