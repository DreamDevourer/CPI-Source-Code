// PemException
using System;
using System.IO;

[Serializable]
public class PemException : IOException
{
	public PemException(string message)
		: base(message)
	{
	}

	public PemException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
