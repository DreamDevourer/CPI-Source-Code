// GetNotificationsResponse
using Disney.Mix.SDK.Internal.MixDomain;
using System.Collections.Generic;

public class GetNotificationsResponse : BaseResponse
{
	public long? LastNotificationTimestamp;

	public long? NotificationSequenceCounter;

	public List<AddFriendshipNotification> AddFriendship;

	public List<AddFriendshipInvitationNotification> AddFriendshipInvitation;

	public List<AddAlertNotification> AddAlert;

	public List<ClearAlertNotification> ClearAlert;

	public List<RemoveFriendshipInvitationNotification> RemoveFriendshipInvitation;

	public List<RemoveFriendshipNotification> RemoveFriendship;

	public List<RemoveFriendshipTrustNotification> RemoveFriendshipTrust;
}
