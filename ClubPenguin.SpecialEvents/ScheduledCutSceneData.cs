// ScheduledCutSceneData
using Disney.Kelowna.Common;
using System;

[Serializable]
public class ScheduledCutSceneData
{
	[Scene]
	public string CutSceneAdditiveScene;

	public string PlayedKeyName;
}
