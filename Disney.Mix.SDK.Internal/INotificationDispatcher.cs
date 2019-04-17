// INotificationDispatcher
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public interface INotificationDispatcher
{
	event EventHandler<AbstractAddFriendshipNotificationEventArgs> OnFriendshipAdded;

	event EventHandler<AbstractAddFriendshipInvitationNotificationEventArgs> OnFriendshipInvitationAdded;

	event EventHandler<AbstractRemoveFriendshipInvitationNotificationEventArgs> OnFriendshipInvitationRemoved;

	event EventHandler<AbstractRemoveFriendshipNotificationEventArgs> OnFriendshipRemoved;

	event EventHandler<AbstractRemoveFriendshipTrustNotificationEventArgs> OnFriendshipTrustRemoved;

	event EventHandler<AbstractAddAlertNotificationEventArgs> OnAlertAdded;

	event EventHandler<AbstractClearAlertNotificationEventArgs> OnAlertCleared;

	void Dispatch(BaseNotification notification);
}
