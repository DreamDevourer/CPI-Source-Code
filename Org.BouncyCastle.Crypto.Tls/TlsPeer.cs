// TlsPeer
using Org.BouncyCastle.Crypto.Tls;
using System;

public interface TlsPeer
{
	bool ShouldUseGmtUnixTime();

	void NotifySecureRenegotiation(bool secureRenegotiation);

	TlsCompression GetCompression();

	TlsCipher GetCipher();

	void NotifyAlertRaised(byte alertLevel, byte alertDescription, string message, Exception cause);

	void NotifyAlertReceived(byte alertLevel, byte alertDescription);

	void NotifyHandshakeComplete();
}
