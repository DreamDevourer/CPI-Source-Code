// InitEmbeddedAssetsAction
using ClubPenguin;
using Disney.Kelowna.Common;
using Disney.Kelowna.Common.GameObjectTree;
using Disney.LaunchPadFramework;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitContentSystemAction))]
public class InitEmbeddedAssetsAction : InitActionComponent
{
	public string ContentKey;

	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		TreeNodeDefinitionContentKey key = new TreeNodeDefinitionContentKey(ContentKey);
		Content.LoadAsync(OnTreeNodeDefinitionLoaded, key);
		yield break;
	}

	private void OnTreeNodeDefinitionLoaded(string key, TreeNodeDefinition nodeDefinition)
	{
		Content.Unload<GameObject>(ContentKey, unloadAllObjects: true);
	}
}
