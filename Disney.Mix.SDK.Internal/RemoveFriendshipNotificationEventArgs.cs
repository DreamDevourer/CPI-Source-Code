// RemoveFriendshipNotificationEventArgs
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;

public class RemoveFriendshipNotificationEventArgs : AbstractRemoveFriendshipNotificationEventArgs
{
	public override RemoveFriendshipNotification Notification
	{
		get;
		protected set;
	}

	public RemoveFriendshipNotificationEventArgs(RemoveFriendshipNotification notification)
	{
		Notification = notification;
	}
}
