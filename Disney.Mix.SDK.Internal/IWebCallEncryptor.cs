// IWebCallEncryptor
public interface IWebCallEncryptor
{
	string ContentType
	{
		get;
	}

	string SessionId
	{
		get;
	}

	byte[] Encrypt(byte[] bytes);

	byte[] Decrypt(byte[] bytes);
}
