// SizzleClipDefinition
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using Newtonsoft.Json;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/Chat/SizzleClip")]
public class SizzleClipDefinition : StaticGameDataDefinition, IMemberLocked
{
	[StaticGameDataDefinitionId]
	public int Id;

	public string AnimationHash;

	public float IconAnimationTime;

	[SerializeField]
	[JsonProperty]
	private bool isMemberOnly;

	public bool IsMemberOnly => isMemberOnly;
}
