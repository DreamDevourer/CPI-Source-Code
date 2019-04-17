// IAgeBand
using Disney.Mix.SDK;
using System.Collections.Generic;

public interface IAgeBand
{
	IRegistrationPermissions Permissions
	{
		get;
	}

	IEnumerable<ILegalDocument> LegalDocuments
	{
		get;
	}

	IEnumerable<string> LegalDocumentsTypeOrder
	{
		get;
	}

	IEnumerable<IMarketingItem> Marketing
	{
		get;
	}

	AgeBandType AgeBandType
	{
		get;
	}

	string CountryCode
	{
		get;
	}
}
