// AbstractGuestControllerAccessTokenChangedEventArgs
using System;

public abstract class AbstractGuestControllerAccessTokenChangedEventArgs : EventArgs
{
	public string GuestControllerAccessToken
	{
		get;
		protected set;
	}
}
