// LegalGroup
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class LegalGroup
{
	public List<string> documentTypeOrder
	{
		get;
		set;
	}

	public Dictionary<string, DocumentType> documents
	{
		get;
		set;
	}

	public List<LegalProxy> CREATE
	{
		get;
		set;
	}
}
