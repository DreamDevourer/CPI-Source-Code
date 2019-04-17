// PasswordException
using System;
using System.IO;

[Serializable]
public class PasswordException : IOException
{
	public PasswordException(string message)
		: base(message)
	{
	}

	public PasswordException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
