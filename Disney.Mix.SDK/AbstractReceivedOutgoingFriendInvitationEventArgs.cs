// AbstractReceivedOutgoingFriendInvitationEventArgs
using Disney.Mix.SDK;
using System;

public abstract class AbstractReceivedOutgoingFriendInvitationEventArgs : EventArgs
{
	public IOutgoingFriendInvitation Invitation
	{
		get;
		protected set;
	}
}
