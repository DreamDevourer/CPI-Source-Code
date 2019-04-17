// GetNotificationsRequest
using Disney.Mix.SDK.Internal.MixDomain;
using System.Collections.Generic;

public class GetNotificationsRequest : BaseUserRequest
{
	public long? CreatedAfter;

	public List<long?> ExcludeNotificationIds;
}
