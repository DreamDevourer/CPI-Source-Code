// AddFriendshipInvitationNotificationEventArgs
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;

public class AddFriendshipInvitationNotificationEventArgs : AbstractAddFriendshipInvitationNotificationEventArgs
{
	public override AddFriendshipInvitationNotification Notification
	{
		get;
		protected set;
	}

	public AddFriendshipInvitationNotificationEventArgs(AddFriendshipInvitationNotification notification)
	{
		Notification = notification;
	}
}
