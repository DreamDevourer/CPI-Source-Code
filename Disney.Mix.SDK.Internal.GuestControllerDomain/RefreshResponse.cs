// RefreshResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class RefreshResponse : GuestControllerWebCallResponse
{
	public RefreshData data
	{
		get;
		set;
	}
}
