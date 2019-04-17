// GetNotificationsSinceSequenceRequest
using Disney.Mix.SDK.Internal.MixDomain;
using System.Collections.Generic;

public class GetNotificationsSinceSequenceRequest : BaseUserRequest
{
	public long? SequenceNumber;

	public List<long?> ExcludeNotificationSequenceNumbers;
}
