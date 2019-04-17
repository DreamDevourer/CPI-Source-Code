// GetPermissionsResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class GetPermissionsResponse : GuestControllerWebCallResponse
{
	public GetPermissionsData data
	{
		get;
		set;
	}
}
