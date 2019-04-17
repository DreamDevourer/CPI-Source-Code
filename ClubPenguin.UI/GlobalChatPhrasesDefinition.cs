// GlobalChatPhrasesDefinition
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class GlobalChatPhrasesDefinition : StaticGameDataDefinition
{
	public List<ChatPhraseDefinition> ChatPhraseDefinitions = new List<ChatPhraseDefinition>();
}
