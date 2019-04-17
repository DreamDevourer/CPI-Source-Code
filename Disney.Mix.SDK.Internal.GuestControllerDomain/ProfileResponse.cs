// ProfileResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class ProfileResponse : GuestControllerWebCallResponse
{
	public ProfileData data
	{
		get;
		set;
	}
}
