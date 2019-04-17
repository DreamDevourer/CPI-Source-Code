// TargetWinWatcher
using ClubPenguin.Core;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Watcher/Targets/TargetWin")]
public class TargetWinWatcher : TaskWatcher
{
	public override object GetExportParameters()
	{
		return "none";
	}

	public override string GetWatcherType()
	{
		return "targetplaygroundwin";
	}
}
