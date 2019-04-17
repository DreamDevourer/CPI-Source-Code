// TlsServerContextImpl
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Security;

internal class TlsServerContextImpl : AbstractTlsContext, TlsServerContext, TlsContext
{
	public override bool IsServer => true;

	internal TlsServerContextImpl(SecureRandom secureRandom, SecurityParameters securityParameters)
		: base(secureRandom, securityParameters)
	{
	}
}
