// AbstractReceivedIncomingFriendInvitationEventArgs
using Disney.Mix.SDK;
using System;

public abstract class AbstractReceivedIncomingFriendInvitationEventArgs : EventArgs
{
	public IIncomingFriendInvitation Invitation
	{
		get;
		protected set;
	}
}
