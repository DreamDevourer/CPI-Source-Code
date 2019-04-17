// CellPhoneQuestActivityDefinition
using ClubPenguin.Adventure;
using ClubPenguin.CellPhone;
using System;
using UnityEngine;

[Serializable]
public class CellPhoneQuestActivityDefinition : CellPhoneActivityDefinition
{
	[HideInInspector]
	public QuestDefinition Quest;
}
