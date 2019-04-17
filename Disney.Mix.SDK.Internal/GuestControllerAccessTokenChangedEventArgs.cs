// GuestControllerAccessTokenChangedEventArgs
using Disney.Mix.SDK;

public class GuestControllerAccessTokenChangedEventArgs : AbstractGuestControllerAccessTokenChangedEventArgs
{
	public GuestControllerAccessTokenChangedEventArgs(string guestControllerAccessToken)
	{
		base.GuestControllerAccessToken = guestControllerAccessToken;
	}
}
