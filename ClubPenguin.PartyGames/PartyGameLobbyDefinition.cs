// PartyGameLobbyDefinition
using ClubPenguin.Core;
using ClubPenguin.PartyGames;
using Newtonsoft.Json;
using System;
using UnityEngine;

[Serializable]
[JsonConverter(typeof(PartyGameLobbyDefinitionJsonConverter))]
public abstract class PartyGameLobbyDefinition : ScriptableObject, ICustomExportScriptableObject
{
	public class PartyGameLobbyDefinitionJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(PartyGameLobbyDefinition).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, JsonUtility.ToJson(value));
		}
	}
}
