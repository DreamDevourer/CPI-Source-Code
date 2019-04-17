// IglooCameraOverrideStateData
using ClubPenguin;
using ClubPenguin.Igloo;
using Disney.Kelowna.Common;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class IglooCameraOverrideStateData : ScopedData
{
	public bool UpdateTargetAndRail;

	private SceneStateData.SceneState overrideState;

	private bool overrideToLightingRail;

	public SceneStateData.SceneState OverrideState
	{
		get
		{
			return overrideState;
		}
		set
		{
			this.OverrideStateUpdated.InvokeSafe(value);
			overrideState = value;
		}
	}

	public bool OverrideToLightingRail
	{
		get
		{
			return overrideToLightingRail;
		}
		set
		{
			this.OverrideToLightingRailUpdated.InvokeSafe(value);
			overrideToLightingRail = value;
		}
	}

	protected override string scopeID => CPDataScopes.Scene.ToString();

	protected override Type monoBehaviourType => typeof(IglooCameraOverrideStateDataMonoBehaviour);

	public event Action<SceneStateData.SceneState> OverrideStateUpdated;

	public event Action<bool> OverrideToLightingRailUpdated;

	protected override void notifyWillBeDestroyed()
	{
		this.OverrideStateUpdated = null;
		this.OverrideToLightingRailUpdated = null;
	}
}
