// TlsCompression
using System.IO;

public interface TlsCompression
{
	Stream Compress(Stream output);

	Stream Decompress(Stream output);
}
