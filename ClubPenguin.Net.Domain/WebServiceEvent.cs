// WebServiceEvent
using ClubPenguin.Net.Domain;
using LitJson;

public struct WebServiceEvent
{
	public int type;

	public JsonData details;

	static WebServiceEvent()
	{
		JsonMapper.RegisterExporter<WebServiceEvent>(exportWebServiceEvent);
	}

	private static void exportWebServiceEvent(WebServiceEvent obj, JsonWriter writer)
	{
		writer.WriteObjectStart();
		writer.WritePropertyName("type");
		writer.Write(obj.type);
		writer.WritePropertyName("details");
		obj.details.ToJson(writer);
		writer.WriteObjectEnd();
	}
}
