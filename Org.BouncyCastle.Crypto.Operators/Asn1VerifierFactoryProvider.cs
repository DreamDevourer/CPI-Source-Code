// Asn1VerifierFactoryProvider
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using System.Collections;

public class Asn1VerifierFactoryProvider : IVerifierFactoryProvider
{
	private readonly AsymmetricKeyParameter publicKey;

	public IEnumerable SignatureAlgNames => X509Utilities.GetAlgNames();

	public Asn1VerifierFactoryProvider(AsymmetricKeyParameter publicKey)
	{
		this.publicKey = publicKey;
	}

	public IVerifierFactory CreateVerifierFactory(object algorithmDetails)
	{
		return new Asn1VerifierFactory((AlgorithmIdentifier)algorithmDetails, publicKey);
	}
}
