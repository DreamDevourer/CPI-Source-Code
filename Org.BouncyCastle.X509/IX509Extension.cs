// IX509Extension
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Utilities.Collections;
using System;

public interface IX509Extension
{
	ISet GetCriticalExtensionOids();

	ISet GetNonCriticalExtensionOids();

	[Obsolete("Use version taking a DerObjectIdentifier instead")]
	Asn1OctetString GetExtensionValue(string oid);

	Asn1OctetString GetExtensionValue(DerObjectIdentifier oid);
}
