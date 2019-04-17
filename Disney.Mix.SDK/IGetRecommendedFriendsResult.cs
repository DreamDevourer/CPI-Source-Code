// IGetRecommendedFriendsResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public interface IGetRecommendedFriendsResult
{
	bool Success
	{
		get;
	}

	IEnumerable<IUnidentifiedUser> Users
	{
		get;
	}
}
