// AvatarColorDefinition
using ClubPenguin.Core.StaticGameData;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/AvatarColour")]
public class AvatarColorDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public int ColorId;

	public int ViewOrder;

	public string ColorName;

	public string Color;
}
