// ChatPhraseDefinition
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.UI;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/Chat/Phrase")]
public class ChatPhraseDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public string Token;

	public SizzleClipDefinitionKey SizzleClipKey;
}
