// AbstractRemoveFriendshipNotificationEventArgs
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public abstract class AbstractRemoveFriendshipNotificationEventArgs : EventArgs
{
	public abstract RemoveFriendshipNotification Notification
	{
		get;
		protected set;
	}
}
