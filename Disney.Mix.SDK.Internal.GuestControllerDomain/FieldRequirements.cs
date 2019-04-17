// FieldRequirements
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System.Collections.Generic;

public class FieldRequirements : BaseFieldRequirements
{
	public Dictionary<string, Dictionary<string, BaseFieldRequirements>> type
	{
		get;
		set;
	}
}
