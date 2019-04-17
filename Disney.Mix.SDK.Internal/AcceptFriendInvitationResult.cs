// AcceptFriendInvitationResult
using Disney.Mix.SDK;

public class AcceptFriendInvitationResult : IAcceptFriendInvitationResult
{
	public bool Success
	{
		get;
		private set;
	}

	public IFriend Friend
	{
		get;
		private set;
	}

	public AcceptFriendInvitationResult(bool success, IFriend friend)
	{
		Success = success;
		Friend = friend;
	}
}
