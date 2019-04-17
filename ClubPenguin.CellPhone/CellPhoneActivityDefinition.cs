// CellPhoneActivityDefinition
using ClubPenguin.CellPhone;
using ClubPenguin.Core.StaticGameData;
using DevonLocalization.Core;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class CellPhoneActivityDefinition : StaticGameDataDefinition
{
	public ActivityScreenPriorities WidgetGlobalPriorityOverride = ActivityScreenPriorities.None;

	public ActivityScreenPriorities WidgetPriority = ActivityScreenPriorities.Tenth;

	public PrefabContentKey WidgetPrefabKey;

	public bool IsMemberOnly;

	[LocalizationToken]
	public string NotificationMessageToken;
}
