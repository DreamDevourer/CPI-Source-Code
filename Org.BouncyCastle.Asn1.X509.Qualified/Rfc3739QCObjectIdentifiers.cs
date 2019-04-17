// Rfc3739QCObjectIdentifiers
using Org.BouncyCastle.Asn1;

public sealed class Rfc3739QCObjectIdentifiers
{
	public static readonly DerObjectIdentifier IdQcs = new DerObjectIdentifier("1.3.6.1.5.5.7.11");

	public static readonly DerObjectIdentifier IdQcsPkixQCSyntaxV1 = new DerObjectIdentifier(IdQcs + ".1");

	public static readonly DerObjectIdentifier IdQcsPkixQCSyntaxV2 = new DerObjectIdentifier(IdQcs + ".2");

	private Rfc3739QCObjectIdentifiers()
	{
	}
}
