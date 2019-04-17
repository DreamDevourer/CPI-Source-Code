// AbstractFriendInvitationAcceptedEventArgs
using Disney.Mix.SDK;
using System;

public abstract class AbstractFriendInvitationAcceptedEventArgs : EventArgs
{
	public bool TrustAccepted
	{
		get;
		protected set;
	}

	public IFriend Friend
	{
		get;
		protected set;
	}
}
