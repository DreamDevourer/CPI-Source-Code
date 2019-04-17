// CertPolicyID
using Org.BouncyCastle.Asn1;

public class CertPolicyID : DerObjectIdentifier
{
	public CertPolicyID(string id)
		: base(id)
	{
	}
}
