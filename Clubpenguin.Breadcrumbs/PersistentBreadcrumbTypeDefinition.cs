// PersistentBreadcrumbTypeDefinition
using ClubPenguin.Breadcrumbs;
using ClubPenguin.Core.StaticGameData;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/PersistentBreadcrumbType")]
public class PersistentBreadcrumbTypeDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public int Type;

	internal static string ToStaticBreadcrumb(int type, string instanceId)
	{
		return $"P{type}_{instanceId}";
	}

	public override bool Equals(object other)
	{
		if (other is PersistentBreadcrumbTypeDefinition)
		{
			if (other == null)
			{
				return false;
			}
			return (other as PersistentBreadcrumbTypeDefinition).Type == Type;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Type.GetHashCode();
	}
}
