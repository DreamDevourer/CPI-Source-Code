// PgpDataValidationException
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;

[Serializable]
public class PgpDataValidationException : PgpException
{
	public PgpDataValidationException()
	{
	}

	public PgpDataValidationException(string message)
		: base(message)
	{
	}

	public PgpDataValidationException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
