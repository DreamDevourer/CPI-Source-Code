// NotificationResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class NotificationResponse : GuestControllerWebCallResponse
{
	public NotificationData data
	{
		get;
		set;
	}
}
