// CmsAuthenticatedGenerator
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Security;

public class CmsAuthenticatedGenerator : CmsEnvelopedGenerator
{
	public CmsAuthenticatedGenerator()
	{
	}

	public CmsAuthenticatedGenerator(SecureRandom rand)
		: base(rand)
	{
	}
}
