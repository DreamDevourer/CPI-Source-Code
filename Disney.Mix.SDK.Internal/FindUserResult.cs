// FindUserResult
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class FindUserResult : IFindUserResult
{
	private readonly IInternalUnidentifiedUser user;

	public bool Success
	{
		get;
		private set;
	}

	public IUnidentifiedUser User => user;

	public FindUserResult(bool success, IInternalUnidentifiedUser user)
	{
		Success = success;
		this.user = user;
	}
}
