// GetLinkedUsersFailedEmailNotVerifiedResult
using Disney.Mix.SDK;
using System.Collections.Generic;
using System.Linq;

public class GetLinkedUsersFailedEmailNotVerifiedResult : IGetLinkedUsersFailedEmailNotVerifiedResult, IGetLinkedUsersResult
{
	public bool Success => false;

	public IEnumerable<ILinkedUser> LinkedUsers => Enumerable.Empty<ILinkedUser>();
}
