// TlsClientContextImpl
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Security;

internal class TlsClientContextImpl : AbstractTlsContext, TlsClientContext, TlsContext
{
	public override bool IsServer => false;

	internal TlsClientContextImpl(SecureRandom secureRandom, SecurityParameters securityParameters)
		: base(secureRandom, securityParameters)
	{
	}
}
