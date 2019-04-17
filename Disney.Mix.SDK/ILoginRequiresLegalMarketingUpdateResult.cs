// ILoginRequiresLegalMarketingUpdateResult
using Disney.Mix.SDK;
using System.Collections.Generic;

public interface ILoginRequiresLegalMarketingUpdateResult : ILoginResult
{
	IEnumerable<ILegalDocument> LegalDocuments
	{
		get;
	}

	IEnumerable<IMarketingItem> Marketing
	{
		get;
	}
}
