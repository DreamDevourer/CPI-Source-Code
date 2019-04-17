// RemoveFriendshipTrustNotificationEventArgs
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;

public class RemoveFriendshipTrustNotificationEventArgs : AbstractRemoveFriendshipTrustNotificationEventArgs
{
	public override RemoveFriendshipTrustNotification Notification
	{
		get;
		protected set;
	}

	public RemoveFriendshipTrustNotificationEventArgs(RemoveFriendshipTrustNotification notification)
	{
		Notification = notification;
	}
}
