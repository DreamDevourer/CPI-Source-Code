// TlsSrpGroupVerifier
using Org.BouncyCastle.Crypto.Parameters;

public interface TlsSrpGroupVerifier
{
	bool Accept(Srp6GroupParameters group);
}
