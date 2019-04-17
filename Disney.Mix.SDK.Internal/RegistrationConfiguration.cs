// RegistrationConfiguration
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System;

public class RegistrationConfiguration : IInternalRegistrationConfiguration, IRegistrationConfiguration
{
	private readonly SiteConfigurationData siteConfig;

	private readonly IAgeBandBuilder ageBandBuilder;

	public RegistrationConfiguration(SiteConfigurationData siteConfig, IAgeBandBuilder ageBandBuilder)
	{
		this.siteConfig = siteConfig;
		this.ageBandBuilder = ageBandBuilder;
	}

	public void GetRegistrationAgeBand(int age, string languageCode, Action<IGetAgeBandResult> callback)
	{
		ageBandBuilder.Build(siteConfig, age, languageCode, registration: true, callback);
	}

	public void GetRegistrationAgeBand(string ageBandKey, int age, string languageCode, Action<IGetAgeBandResult> callback)
	{
		ageBandBuilder.Build(siteConfig, ageBandKey, age, languageCode, registration: true, callback);
	}

	public void GetUpdateAgeBand(int age, string languageCode, Action<IGetAgeBandResult> callback)
	{
		ageBandBuilder.Build(siteConfig, age, languageCode, registration: false, callback);
	}

	public void GetUpdateAgeBand(string ageBandKey, int age, string languageCode, Action<IGetAgeBandResult> callback)
	{
		ageBandBuilder.Build(siteConfig, ageBandKey, age, languageCode, registration: false, callback);
	}
}
