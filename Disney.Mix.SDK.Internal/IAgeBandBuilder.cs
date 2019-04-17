// IAgeBandBuilder
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System;

public interface IAgeBandBuilder
{
	void Build(SiteConfigurationData siteConfig, int age, string languageCode, bool registration, Action<IGetAgeBandResult> callback);

	void Build(SiteConfigurationData siteConfig, string ageBandKey, int age, string languageCode, bool registration, Action<IGetAgeBandResult> callback);
}
