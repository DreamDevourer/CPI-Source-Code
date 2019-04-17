// KeyDerivationFunc
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;

public class KeyDerivationFunc : AlgorithmIdentifier
{
	internal KeyDerivationFunc(Asn1Sequence seq)
		: base(seq)
	{
	}

	public KeyDerivationFunc(DerObjectIdentifier id, Asn1Encodable parameters)
		: base(id, parameters)
	{
	}
}
