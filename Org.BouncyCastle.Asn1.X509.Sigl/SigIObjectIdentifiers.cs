// SigIObjectIdentifiers
using Org.BouncyCastle.Asn1;

public sealed class SigIObjectIdentifiers
{
	public static readonly DerObjectIdentifier IdSigI = new DerObjectIdentifier("1.3.36.8");

	public static readonly DerObjectIdentifier IdSigIKP = new DerObjectIdentifier(IdSigI + ".2");

	public static readonly DerObjectIdentifier IdSigICP = new DerObjectIdentifier(IdSigI + ".1");

	public static readonly DerObjectIdentifier IdSigION = new DerObjectIdentifier(IdSigI + ".4");

	public static readonly DerObjectIdentifier IdSigIKPDirectoryService = new DerObjectIdentifier(IdSigIKP + ".1");

	public static readonly DerObjectIdentifier IdSigIONPersonalData = new DerObjectIdentifier(IdSigION + ".1");

	public static readonly DerObjectIdentifier IdSigICPSigConform = new DerObjectIdentifier(IdSigICP + ".1");

	private SigIObjectIdentifiers()
	{
	}
}
