// IDataReaderProvider
using JsonFx.Json;

public interface IDataReaderProvider
{
	IDataReader Find(string contentTypeHeader);
}
