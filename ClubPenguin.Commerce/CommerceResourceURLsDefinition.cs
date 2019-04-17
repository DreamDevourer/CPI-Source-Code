// CommerceResourceURLsDefinition
using ClubPenguin.Core.StaticGameData;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/CommerceResourceURLs")]
public class CommerceResourceURLsDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public string Id;

	public string BaseURL;

	public string[] JavascriptURLs;

	public string[] CSSURLs;
}
