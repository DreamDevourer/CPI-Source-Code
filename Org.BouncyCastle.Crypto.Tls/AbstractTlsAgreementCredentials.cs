// AbstractTlsAgreementCredentials
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Tls;

public abstract class AbstractTlsAgreementCredentials : AbstractTlsCredentials, TlsAgreementCredentials, TlsCredentials
{
	public abstract byte[] GenerateAgreement(AsymmetricKeyParameter peerPublicKey);
}
