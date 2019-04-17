// BerSetGenerator
using Org.BouncyCastle.Asn1;
using System.IO;

public class BerSetGenerator : BerGenerator
{
	public BerSetGenerator(Stream outStream)
		: base(outStream)
	{
		WriteBerHeader(49);
	}

	public BerSetGenerator(Stream outStream, int tagNo, bool isExplicit)
		: base(outStream, tagNo, isExplicit)
	{
		WriteBerHeader(49);
	}
}
