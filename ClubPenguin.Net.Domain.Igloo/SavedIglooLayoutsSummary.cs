// SavedIglooLayoutsSummary
using ClubPenguin.Net.Domain.Igloo;
using System;
using System.Collections.Generic;

[Serializable]
public class SavedIglooLayoutsSummary
{
	public IglooVisibility visibility;

	public long? activeLayoutId;

	public List<SavedIglooLayoutSummary> layouts;

	public ActiveLayoutServerChangeNotification activeLayoutServerChangeNotification;
}
