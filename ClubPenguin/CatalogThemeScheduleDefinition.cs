// CatalogThemeScheduleDefinition
using ClubPenguin.Core.StaticGameData;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/CatalogThemeSchedule")]
public class CatalogThemeScheduleDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public int Id;

	public int Day;

	public int Month;

	public int Year;

	public int CatalogThemeId;

	public override string ToString()
	{
		return $"[CatalogThemeScheduleDefinition] Id: {Id}, Day: {Day}, Month: {Month}, Year: {Year}, Catalog Theme Id: {CatalogThemeId}";
	}
}
