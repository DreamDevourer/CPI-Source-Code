// TlsAgreementCredentials
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Tls;

public interface TlsAgreementCredentials : TlsCredentials
{
	byte[] GenerateAgreement(AsymmetricKeyParameter peerPublicKey);
}
