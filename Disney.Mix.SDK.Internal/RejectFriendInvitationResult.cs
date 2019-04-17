// RejectFriendInvitationResult
using Disney.Mix.SDK;

public class RejectFriendInvitationResult : IRejectFriendInvitationResult
{
	public bool Success
	{
		get;
		private set;
	}

	public RejectFriendInvitationResult(bool success)
	{
		Success = success;
	}
}
