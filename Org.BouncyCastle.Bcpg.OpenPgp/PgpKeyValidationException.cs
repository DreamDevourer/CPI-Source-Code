// PgpKeyValidationException
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;

[Serializable]
public class PgpKeyValidationException : PgpException
{
	public PgpKeyValidationException()
	{
	}

	public PgpKeyValidationException(string message)
		: base(message)
	{
	}

	public PgpKeyValidationException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
