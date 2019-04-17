// PermissionResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class PermissionResponse : GuestControllerWebCallResponse
{
	public Permission data
	{
		get;
		set;
	}
}
