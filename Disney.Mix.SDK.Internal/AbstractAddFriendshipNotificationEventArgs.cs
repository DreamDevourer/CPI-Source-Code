// AbstractAddFriendshipNotificationEventArgs
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public abstract class AbstractAddFriendshipNotificationEventArgs : EventArgs
{
	public abstract AddFriendshipNotification Notification
	{
		get;
		protected set;
	}
}
