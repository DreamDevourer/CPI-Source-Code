// TaskDefinitionContentKey
using ClubPenguin.Task;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class TaskDefinitionContentKey : TypedAssetContentKey<TaskDefinition>
{
	public TaskDefinitionContentKey(string key)
		: base(key)
	{
	}
}
