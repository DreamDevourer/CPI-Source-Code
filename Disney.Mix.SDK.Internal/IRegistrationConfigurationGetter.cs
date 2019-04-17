// IRegistrationConfigurationGetter
using Disney.Mix.SDK.Internal;
using System;

public interface IRegistrationConfigurationGetter
{
	void Get(Action<IInternalGetRegistrationConfigurationResult> callback);

	void Get(string countryCode, Action<IInternalGetRegistrationConfigurationResult> callback);
}
