// AbstractUnfriendedEventArgs
using Disney.Mix.SDK;
using System;

public abstract class AbstractUnfriendedEventArgs : EventArgs
{
	public abstract IFriend ExFriend
	{
		get;
		protected set;
	}
}
