// IRegistrationConfigurationGetter
using Disney.Mix.SDK;
using System;

public interface IRegistrationConfigurationGetter
{
	void Get(Action<IGetRegistrationConfigurationResult> callback);

	void Get(string countryCode, Action<IGetRegistrationConfigurationResult> callback);
}
