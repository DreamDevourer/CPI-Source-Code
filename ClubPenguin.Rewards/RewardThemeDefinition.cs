// RewardThemeDefinition
using ClubPenguin.Core.StaticGameData;
using DevonLocalization.Core;
using Disney.Kelowna.Common;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/RewardThemeDefinition")]
public class RewardThemeDefinition : StaticGameDataDefinition
{
	public int Id;

	[LocalizationToken]
	public string ShortThemeToken;

	public string LongThemeToken;

	public SpriteContentKey ThemeIconContentKey;
}
