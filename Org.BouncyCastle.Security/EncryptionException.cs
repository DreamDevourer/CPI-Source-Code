// EncryptionException
using System;
using System.IO;

[Serializable]
public class EncryptionException : IOException
{
	public EncryptionException(string message)
		: base(message)
	{
	}

	public EncryptionException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
