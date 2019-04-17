// ILegalMarketingErrorsBuilder
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System;

public interface ILegalMarketingErrorsBuilder
{
	void BuildErrors(ISession session, GuestApiErrorCollection errors, Action<BuildLegalMarketingErrorsResult> successCallback, Action failureCallback);
}
