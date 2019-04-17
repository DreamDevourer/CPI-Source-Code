// AbstractRemoveFriendshipTrustNotificationEventArgs
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public abstract class AbstractRemoveFriendshipTrustNotificationEventArgs : EventArgs
{
	public abstract RemoveFriendshipTrustNotification Notification
	{
		get;
		protected set;
	}
}
