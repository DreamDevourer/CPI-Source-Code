// AbstractRemoveFriendshipInvitationNotificationEventArgs
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public abstract class AbstractRemoveFriendshipInvitationNotificationEventArgs : EventArgs
{
	public abstract RemoveFriendshipInvitationNotification Notification
	{
		get;
		protected set;
	}
}
