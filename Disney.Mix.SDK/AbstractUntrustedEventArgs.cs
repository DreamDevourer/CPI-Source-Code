// AbstractUntrustedEventArgs
using Disney.Mix.SDK;
using System;

public abstract class AbstractUntrustedEventArgs : EventArgs
{
	public abstract IFriend ExTrustedFriend
	{
		get;
		protected set;
	}
}
