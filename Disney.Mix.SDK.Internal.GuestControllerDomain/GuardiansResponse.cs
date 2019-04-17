// GuardiansResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class GuardiansResponse : GuestControllerWebCallResponse
{
	public GuardiansData data
	{
		get;
		set;
	}
}
