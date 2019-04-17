// SigOutputStream
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO;

internal class SigOutputStream : BaseOutputStream
{
	private readonly ISigner sig;

	internal SigOutputStream(ISigner sig)
	{
		this.sig = sig;
	}

	public override void WriteByte(byte b)
	{
		try
		{
			sig.Update(b);
		}
		catch (SignatureException arg)
		{
			throw new CmsStreamException("signature problem: " + arg);
		}
	}

	public override void Write(byte[] b, int off, int len)
	{
		try
		{
			sig.BlockUpdate(b, off, len);
		}
		catch (SignatureException arg)
		{
			throw new CmsStreamException("signature problem: " + arg);
		}
	}
}
