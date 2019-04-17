// Friend
using Disney.Mix.SDK;

public class Friend
{
	public readonly IFriend MixFriend;

	public string DisplayName => (MixFriend != null) ? MixFriend.DisplayName.Text : null;

	public string Swid => (MixFriend != null) ? MixFriend.Id : null;

	public Friend(IFriend friend)
	{
		MixFriend = friend;
	}
}
