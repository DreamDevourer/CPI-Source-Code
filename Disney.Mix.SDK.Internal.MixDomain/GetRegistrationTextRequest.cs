// GetRegistrationTextRequest
using Disney.Mix.SDK.Internal.MixDomain;
using System.Collections.Generic;

public class GetRegistrationTextRequest : BaseUserRequest
{
	public string LanguageCode;

	public List<string> TextCodes;

	public string CountryCode;

	public string AgeBand;
}
