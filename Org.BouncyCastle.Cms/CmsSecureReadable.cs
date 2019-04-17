// CmsSecureReadable
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto.Parameters;

internal interface CmsSecureReadable
{
	AlgorithmIdentifier Algorithm
	{
		get;
	}

	object CryptoObject
	{
		get;
	}

	CmsReadable GetReadable(KeyParameter key);
}
