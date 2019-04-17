// RecipientInfoGenerator
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

internal interface RecipientInfoGenerator
{
	RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random);
}
