// IRegistrationConfiguration
using Disney.Mix.SDK;
using System;

public interface IRegistrationConfiguration
{
	void GetRegistrationAgeBand(int age, string languageCode, Action<IGetAgeBandResult> callback);

	void GetUpdateAgeBand(int age, string languageCode, Action<IGetAgeBandResult> callback);
}
