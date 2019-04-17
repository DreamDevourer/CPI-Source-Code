// SiteConfigurationResponse
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;

public class SiteConfigurationResponse : GuestControllerWebCallResponse
{
	public SiteConfigurationData data
	{
		get;
		set;
	}
}
