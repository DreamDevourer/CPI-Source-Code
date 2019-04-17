// GetLinkedUsersResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public class GetLinkedUsersResult : IGetLinkedUsersResult
{
	public bool Success
	{
		get;
		private set;
	}

	public IEnumerable<ILinkedUser> LinkedUsers
	{
		get;
		private set;
	}

	public GetLinkedUsersResult(bool success, IEnumerable<ILinkedUser> users)
	{
		Success = success;
		LinkedUsers = users;
	}
}
