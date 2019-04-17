// TutorialDefinition
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.Tutorial;
using Disney.Kelowna.Common;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/Tutorial")]
public class TutorialDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public int Id;

	public TutorialDefinition[] TutorialRequirements = new TutorialDefinition[0];

	public bool IsMemberOnly;

	public int MinimumPenguinAge;

	[Tooltip("True if this tutorial does not complete when finished. Must then be completed elsewhere.")]
	public bool IsNotAutoComplete;

	public FSMContentKey FsmContentKey;
}
