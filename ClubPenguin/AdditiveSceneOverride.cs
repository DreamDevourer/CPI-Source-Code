// AdditiveSceneOverride
using ClubPenguin.Core;
using System;

[Serializable]
public struct AdditiveSceneOverride
{
	public ScheduledEventDateDefinitionKey DateDefinitionKey;

	public string PlayerPrefsKey;

	public string[] AdditiveScenes;
}
