// SearchedUser
using Disney.Mix.SDK;

public class SearchedUser
{
	public readonly IUnidentifiedUser MixSearchedUser;

	public string DisplayName => (MixSearchedUser != null) ? MixSearchedUser.DisplayName.Text : null;

	public SearchedUser(IUnidentifiedUser User)
	{
		MixSearchedUser = User;
	}
}
