// ClearAlertsRequest
using Disney.Mix.SDK.Internal.MixDomain;
using System.Collections.Generic;

public class ClearAlertsRequest : BaseUserRequest
{
	public List<long?> AlertIds;
}
