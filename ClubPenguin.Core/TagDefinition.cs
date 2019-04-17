// TagDefinition
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/Tag")]
public class TagDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public string Tag;

	public TagCategoryDefinition Category;

	[TextArea]
	public string Description;
}
