// TlsProtocolHandler
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Security;
using System;
using System.IO;

[Obsolete("Use 'TlsClientProtocol' instead")]
public class TlsProtocolHandler : TlsClientProtocol
{
	public TlsProtocolHandler(Stream stream, SecureRandom secureRandom)
		: base(stream, stream, secureRandom)
	{
	}

	public TlsProtocolHandler(Stream input, Stream output, SecureRandom secureRandom)
		: base(input, output, secureRandom)
	{
	}
}
