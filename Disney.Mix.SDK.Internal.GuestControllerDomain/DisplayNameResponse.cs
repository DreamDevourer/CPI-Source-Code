// DisplayNameResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class DisplayNameResponse : GuestControllerWebCallResponse
{
	public DisplayNameData data
	{
		get;
		set;
	}
}
