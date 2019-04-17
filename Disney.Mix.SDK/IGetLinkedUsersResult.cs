// IGetLinkedUsersResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public interface IGetLinkedUsersResult
{
	bool Success
	{
		get;
	}

	IEnumerable<ILinkedUser> LinkedUsers
	{
		get;
	}
}
