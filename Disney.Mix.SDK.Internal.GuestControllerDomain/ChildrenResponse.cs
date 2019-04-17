// ChildrenResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class ChildrenResponse : GuestControllerWebCallResponse
{
	public ChildrenData data
	{
		get;
		set;
	}
}
