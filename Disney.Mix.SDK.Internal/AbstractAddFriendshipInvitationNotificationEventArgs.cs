// AbstractAddFriendshipInvitationNotificationEventArgs
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public abstract class AbstractAddFriendshipInvitationNotificationEventArgs : EventArgs
{
	public abstract AddFriendshipInvitationNotification Notification
	{
		get;
		protected set;
	}
}
