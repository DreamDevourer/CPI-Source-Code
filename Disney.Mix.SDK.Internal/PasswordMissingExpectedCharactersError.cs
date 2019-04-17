// PasswordMissingExpectedCharactersError
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class PasswordMissingExpectedCharactersError : AbstractInvalidProfileItemError, IPasswordMissingExpectedCharactersError, IInvalidProfileItemError
{
	public PasswordMissingExpectedCharactersError(string description)
		: base(description)
	{
	}
}
