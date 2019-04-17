// SmimeCapabilitiesAttribute
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Smime;
using Org.BouncyCastle.Asn1.X509;

public class SmimeCapabilitiesAttribute : AttributeX509
{
	public SmimeCapabilitiesAttribute(SmimeCapabilityVector capabilities)
		: base(SmimeAttributes.SmimeCapabilities, new DerSet(new DerSequence(capabilities.ToAsn1EncodableVector())))
	{
	}
}
