// GetUsersByDisplayNameRequest
using Disney.Mix.SDK.Internal.MixDomain;
using System.Collections.Generic;

public class GetUsersByDisplayNameRequest : BaseUserRequest
{
	public List<string> DisplayNames;
}
