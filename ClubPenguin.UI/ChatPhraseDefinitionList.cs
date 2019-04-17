// ChatPhraseDefinitionList
using ClubPenguin.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChatPhraseDefinitionList : ScriptableObject
{
	public List<ChatPhraseDefinition> ChatPhraseDefinitions = new List<ChatPhraseDefinition>();
}
