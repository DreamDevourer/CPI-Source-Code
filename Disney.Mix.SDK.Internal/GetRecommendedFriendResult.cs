// GetRecommendedFriendResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public class GetRecommendedFriendResult : IGetRecommendedFriendsResult
{
	public bool Success
	{
		get;
		private set;
	}

	public IEnumerable<IUnidentifiedUser> Users
	{
		get;
		private set;
	}

	public GetRecommendedFriendResult(bool success, IEnumerable<IUnidentifiedUser> users)
	{
		Success = success;
		Users = users;
	}
}
