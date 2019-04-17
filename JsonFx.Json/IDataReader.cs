// IDataReader
using System;
using System.IO;

public interface IDataReader
{
	string ContentType
	{
		get;
	}

	object Deserialize(TextReader input, Type data);
}
