// MixSessionStartWebCallEncryptor
using Disney.Mix.SDK.Internal;

public class MixSessionStartWebCallEncryptor : IWebCallEncryptor
{
	public string ContentType => "application/json";

	public string SessionId => null;

	public byte[] Encrypt(byte[] bytes)
	{
		return bytes;
	}

	public byte[] Decrypt(byte[] bytes)
	{
		return bytes;
	}
}
