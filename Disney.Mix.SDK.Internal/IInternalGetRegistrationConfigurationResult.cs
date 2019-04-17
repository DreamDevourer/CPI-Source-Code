// IInternalGetRegistrationConfigurationResult
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public interface IInternalGetRegistrationConfigurationResult : IGetRegistrationConfigurationResult
{
	IInternalRegistrationConfiguration InternalConfiguration
	{
		get;
	}
}
