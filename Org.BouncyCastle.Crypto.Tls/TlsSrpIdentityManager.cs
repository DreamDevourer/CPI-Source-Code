// TlsSrpIdentityManager
using Org.BouncyCastle.Crypto.Tls;

public interface TlsSrpIdentityManager
{
	TlsSrpLoginParameters GetLoginParameters(byte[] identity);
}
