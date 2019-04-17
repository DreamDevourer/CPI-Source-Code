// TypedStaticGameDataKey<T,F>
using ClubPenguin.Core.StaticGameData;
using UnityEngine;

public class TypedStaticGameDataKey<T, F> : StaticGameDataKey, ISerializationCallbackReceiver where T : StaticGameDataDefinition
{
	public F Id;

	[SerializeField]
	private string type;

	public string UnderliningTypeString => type;

	public void OnBeforeSerialize()
	{
		if (string.IsNullOrEmpty(type))
		{
			type = StaticGameDataKey.GetTypeString(typeof(T));
		}
	}

	public void OnAfterDeserialize()
	{
	}
}
