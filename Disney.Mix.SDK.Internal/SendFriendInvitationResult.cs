// SendFriendInvitationResult
using Disney.Mix.SDK;

public class SendFriendInvitationResult : ISendFriendInvitationResult
{
	public bool Success
	{
		get;
		private set;
	}

	public IOutgoingFriendInvitation Invitation
	{
		get;
		private set;
	}

	public SendFriendInvitationResult(bool success, IOutgoingFriendInvitation invitation)
	{
		Success = success;
		Invitation = invitation;
	}
}
