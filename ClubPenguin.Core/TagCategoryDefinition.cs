// TagCategoryDefinition
using ClubPenguin.Core.StaticGameData;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/TagCategory")]
public class TagCategoryDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public string CategoryName;

	[TextArea]
	public string Description;
}
