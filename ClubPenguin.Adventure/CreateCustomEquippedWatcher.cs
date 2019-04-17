// CreateCustomEquippedWatcher
using ClubPenguin.Core;
using ClubPenguin.Tags;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Watcher/CreateEquipment")]
public class CreateCustomEquippedWatcher : TaskWatcher
{
	public OutfitTagMatcher TagMatcher;

	public override object GetExportParameters()
	{
		return TagMatcher.GetExportParameters();
	}

	public override string GetWatcherType()
	{
		return "createCustomEquipment";
	}
}
