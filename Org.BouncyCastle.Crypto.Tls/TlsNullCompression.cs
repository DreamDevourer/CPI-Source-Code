// TlsNullCompression
using Org.BouncyCastle.Crypto.Tls;
using System.IO;

public class TlsNullCompression : TlsCompression
{
	public virtual Stream Compress(Stream output)
	{
		return output;
	}

	public virtual Stream Decompress(Stream output)
	{
		return output;
	}
}
