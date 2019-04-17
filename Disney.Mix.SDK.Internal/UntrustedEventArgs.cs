// UntrustedEventArgs
using Disney.Mix.SDK;

internal class UntrustedEventArgs : AbstractUntrustedEventArgs
{
	public override IFriend ExTrustedFriend
	{
		get;
		protected set;
	}

	public UntrustedEventArgs(IFriend exTrustedFriend)
	{
		ExTrustedFriend = exTrustedFriend;
	}
}
