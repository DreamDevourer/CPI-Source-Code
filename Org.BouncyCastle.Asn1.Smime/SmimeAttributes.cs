// SmimeAttributes
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;

public abstract class SmimeAttributes
{
	public static readonly DerObjectIdentifier SmimeCapabilities = PkcsObjectIdentifiers.Pkcs9AtSmimeCapabilities;

	public static readonly DerObjectIdentifier EncrypKeyPref = PkcsObjectIdentifiers.IdAAEncrypKeyPref;
}
