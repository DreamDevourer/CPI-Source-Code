// GetRegistrationConfigurationEmbargoedCountryResult
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class GetRegistrationConfigurationEmbargoedCountryResult : IInternalGetRegistrationConfigurationResult, IGetRegistrationConfigurationEmbargoedCountryResult, IGetRegistrationConfigurationResult
{
	public bool Success => false;

	public IRegistrationConfiguration Configuration => InternalConfiguration;

	public IInternalRegistrationConfiguration InternalConfiguration => null;
}
