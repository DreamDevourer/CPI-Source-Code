// BerOctetStringParser
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

public class BerOctetStringParser : Asn1OctetStringParser, IAsn1Convertible
{
	private readonly Asn1StreamParser _parser;

	internal BerOctetStringParser(Asn1StreamParser parser)
	{
		_parser = parser;
	}

	public Stream GetOctetStream()
	{
		return new ConstructedOctetStream(_parser);
	}

	public Asn1Object ToAsn1Object()
	{
		try
		{
			return new BerOctetString(Streams.ReadAll(GetOctetStream()));
		}
		catch (IOException ex)
		{
			throw new Asn1ParsingException("IOException converting stream to byte array: " + ex.Message, ex);
		}
	}
}
