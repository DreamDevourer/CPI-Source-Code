// TlsDssSigner
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Crypto.Tls;

public class TlsDssSigner : TlsDsaSigner
{
	protected override byte SignatureAlgorithm => 2;

	public override bool IsValidPublicKey(AsymmetricKeyParameter publicKey)
	{
		return publicKey is DsaPublicKeyParameters;
	}

	protected override IDsa CreateDsaImpl(byte hashAlgorithm)
	{
		return new DsaSigner(new HMacDsaKCalculator(TlsUtilities.CreateHash(hashAlgorithm)));
	}
}
