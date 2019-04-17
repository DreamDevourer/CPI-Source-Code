// IIncomingFriendInvitation
using Disney.Mix.SDK;
using System;

public interface IIncomingFriendInvitation
{
	IUnidentifiedUser Inviter
	{
		get;
	}

	ILocalUser Invitee
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
