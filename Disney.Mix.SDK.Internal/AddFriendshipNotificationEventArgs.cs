// AddFriendshipNotificationEventArgs
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;

public class AddFriendshipNotificationEventArgs : AbstractAddFriendshipNotificationEventArgs
{
	public override AddFriendshipNotification Notification
	{
		get;
		protected set;
	}

	public AddFriendshipNotificationEventArgs(AddFriendshipNotification notification)
	{
		Notification = notification;
	}
}
