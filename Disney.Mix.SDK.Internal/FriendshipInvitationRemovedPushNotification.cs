// FriendshipInvitationRemovedPushNotification
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class FriendshipInvitationRemovedPushNotification : AbstractPushNotification, IFriendshipInvitationRemovedPushNotification, IPushNotification
{
	public FriendshipInvitationRemovedPushNotification(bool notificationsAvailable)
		: base(notificationsAvailable)
	{
	}
}
