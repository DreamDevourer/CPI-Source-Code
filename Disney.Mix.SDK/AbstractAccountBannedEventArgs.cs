// AbstractAccountBannedEventArgs
using Disney.Mix.SDK;
using System;

public abstract class AbstractAccountBannedEventArgs : AbstractAuthenticationLostEventArgs
{
	public DateTime? ExpirationDate
	{
		get;
		protected set;
	}
}
