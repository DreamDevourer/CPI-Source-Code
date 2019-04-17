// JsonDataWriter
using JsonFx.Json;
using System;
using System.IO;
using System.Text;

public class JsonDataWriter : IDataWriter
{
	public const string JsonMimeType = "application/json";

	public const string JsonFileExtension = ".json";

	private readonly JsonWriterSettings Settings;

	public Encoding ContentEncoding => Encoding.UTF8;

	public string ContentType => "application/json";

	public string FileExtension => ".json";

	public JsonDataWriter(JsonWriterSettings settings)
	{
		if (settings == null)
		{
			throw new ArgumentNullException("settings");
		}
		Settings = settings;
	}

	public void Serialize(TextWriter output, object data)
	{
		new JsonWriter(output, Settings).Write(data);
	}

	public static JsonWriterSettings CreateSettings(bool prettyPrint)
	{
		JsonWriterSettings jsonWriterSettings = new JsonWriterSettings();
		jsonWriterSettings.PrettyPrint = prettyPrint;
		return jsonWriterSettings;
	}
}
