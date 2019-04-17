// IOutgoingFriendInvitation
using Disney.Mix.SDK;
using System;

public interface IOutgoingFriendInvitation
{
	ILocalUser Inviter
	{
		get;
	}

	IUnidentifiedUser Invitee
	{
		get;
	}

	bool RequestTrust
	{
		get;
	}

	bool Sent
	{
		get;
	}

	string Id
	{
		get;
	}

	event EventHandler<AbstractFriendInvitationAcceptedEventArgs> OnAccepted;

	event EventHandler<AbstractFriendInvitationRejectedEventArgs> OnRejected;
}
