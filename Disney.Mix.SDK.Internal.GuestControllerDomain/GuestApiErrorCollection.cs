// GuestApiErrorCollection
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class GuestApiErrorCollection
{
	public string keyCategory
	{
		get;
		set;
	}

	public List<GuestApiError> errors
	{
		get;
		set;
	}
}
