// UnfriendedEventArgs
using Disney.Mix.SDK;

internal class UnfriendedEventArgs : AbstractUnfriendedEventArgs
{
	public override IFriend ExFriend
	{
		get;
		protected set;
	}

	public UnfriendedEventArgs(IFriend exFriend)
	{
		ExFriend = exFriend;
	}
}
