// CellPhoneRecurringLocationActivityDefinition
using ClubPenguin.CellPhone;
using System;

[Serializable]
public class CellPhoneRecurringLocationActivityDefinition : CellPhoneScheduledLocationActivityDefinition
{
	public string ActivityStartScheduleCron;

	public string ShowWidgetScheduleCron;
}
