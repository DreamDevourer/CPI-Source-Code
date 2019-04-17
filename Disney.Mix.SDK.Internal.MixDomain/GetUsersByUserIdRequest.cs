// GetUsersByUserIdRequest
using Disney.Mix.SDK.Internal.MixDomain;
using System.Collections.Generic;

public class GetUsersByUserIdRequest : BaseUserRequest
{
	public List<string> UserIds;
}
