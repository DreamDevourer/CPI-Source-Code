// IInternalRegistrationProfile
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public interface IInternalRegistrationProfile : IRegistrationProfile
{
	new bool IsAdultVerified
	{
		get;
		set;
	}

	void Update(Profile profile, DisplayName displayName, IEnumerable<MarketingItem> marketing);

	void UpdateDisplayName(string displayName);
}
