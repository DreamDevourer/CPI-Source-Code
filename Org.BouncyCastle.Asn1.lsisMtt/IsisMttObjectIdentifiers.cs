// IsisMttObjectIdentifiers
using Org.BouncyCastle.Asn1;

public abstract class IsisMttObjectIdentifiers
{
	public static readonly DerObjectIdentifier IdIsisMtt = new DerObjectIdentifier("1.3.36.8");

	public static readonly DerObjectIdentifier IdIsisMttCP = new DerObjectIdentifier(IdIsisMtt + ".1");

	public static readonly DerObjectIdentifier IdIsisMttCPAccredited = new DerObjectIdentifier(IdIsisMttCP + ".1");

	public static readonly DerObjectIdentifier IdIsisMttAT = new DerObjectIdentifier(IdIsisMtt + ".3");

	public static readonly DerObjectIdentifier IdIsisMttATDateOfCertGen = new DerObjectIdentifier(IdIsisMttAT + ".1");

	public static readonly DerObjectIdentifier IdIsisMttATProcuration = new DerObjectIdentifier(IdIsisMttAT + ".2");

	public static readonly DerObjectIdentifier IdIsisMttATAdmission = new DerObjectIdentifier(IdIsisMttAT + ".3");

	public static readonly DerObjectIdentifier IdIsisMttATMonetaryLimit = new DerObjectIdentifier(IdIsisMttAT + ".4");

	public static readonly DerObjectIdentifier IdIsisMttATDeclarationOfMajority = new DerObjectIdentifier(IdIsisMttAT + ".5");

	public static readonly DerObjectIdentifier IdIsisMttATIccsn = new DerObjectIdentifier(IdIsisMttAT + ".6");

	public static readonly DerObjectIdentifier IdIsisMttATPKReference = new DerObjectIdentifier(IdIsisMttAT + ".7");

	public static readonly DerObjectIdentifier IdIsisMttATRestriction = new DerObjectIdentifier(IdIsisMttAT + ".8");

	public static readonly DerObjectIdentifier IdIsisMttATRetrieveIfAllowed = new DerObjectIdentifier(IdIsisMttAT + ".9");

	public static readonly DerObjectIdentifier IdIsisMttATRequestedCertificate = new DerObjectIdentifier(IdIsisMttAT + ".10");

	public static readonly DerObjectIdentifier IdIsisMttATNamingAuthorities = new DerObjectIdentifier(IdIsisMttAT + ".11");

	public static readonly DerObjectIdentifier IdIsisMttATCertInDirSince = new DerObjectIdentifier(IdIsisMttAT + ".12");

	public static readonly DerObjectIdentifier IdIsisMttATCertHash = new DerObjectIdentifier(IdIsisMttAT + ".13");

	public static readonly DerObjectIdentifier IdIsisMttATNameAtBirth = new DerObjectIdentifier(IdIsisMttAT + ".14");

	public static readonly DerObjectIdentifier IdIsisMttATAdditionalInformation = new DerObjectIdentifier(IdIsisMttAT + ".15");

	public static readonly DerObjectIdentifier IdIsisMttATLiabilityLimitationFlag = new DerObjectIdentifier("0.2.262.1.10.12.0");
}
