// AvatarBodyColorAdaptor
using ClubPenguin;
using ClubPenguin.Avatar;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class AvatarBodyColorAdaptor
{
	public static Color GetColorFromDefinitions(Dictionary<int, AvatarColorDefinition> avatarColors, int colorIndex)
	{
		if (avatarColors.TryGetValue(colorIndex, out AvatarColorDefinition value))
		{
			if (!ColorUtility.TryParseHtmlString("#" + value.Color, out Color color))
			{
				return GetRandomColor(avatarColors);
			}
			return color;
		}
		return GetRandomColor(avatarColors);
	}

	public static Color GetRandomColor(Dictionary<int, AvatarColorDefinition> avatarColors)
	{
		System.Random random = new System.Random();
		int[] array = new int[avatarColors.Count];
		avatarColors.Keys.CopyTo(array, 0);
		AvatarColorDefinition avatarColorDefinition = avatarColors[array[random.Next(0, array.Length)]];
		if (!ColorUtility.TryParseHtmlString("#" + avatarColorDefinition.Color, out Color color))
		{
			return AvatarService.DefaultBodyColor;
		}
		return color;
	}
}
