// PgpCompressedData
using Org.BouncyCastle.Apache.Bzip2;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Utilities.Zlib;
using System.IO;

public class PgpCompressedData : PgpObject
{
	private readonly CompressedDataPacket data;

	public CompressionAlgorithmTag Algorithm => data.Algorithm;

	public PgpCompressedData(BcpgInputStream bcpgInput)
	{
		data = (CompressedDataPacket)bcpgInput.ReadPacket();
	}

	public Stream GetInputStream()
	{
		return data.GetInputStream();
	}

	public Stream GetDataStream()
	{
		switch (Algorithm)
		{
		case CompressionAlgorithmTag.Uncompressed:
			return GetInputStream();
		case CompressionAlgorithmTag.Zip:
			return new ZInputStream(GetInputStream(), nowrap: true);
		case CompressionAlgorithmTag.ZLib:
			return new ZInputStream(GetInputStream());
		case CompressionAlgorithmTag.BZip2:
			return new CBZip2InputStream(GetInputStream());
		default:
			throw new PgpException("can't recognise compression algorithm: " + Algorithm);
		}
	}
}
