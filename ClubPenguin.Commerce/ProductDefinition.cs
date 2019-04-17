// ProductDefinition
using ClubPenguin.Core.StaticGameData;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Definition/Product")]
public class ProductDefinition : StaticGameDataDefinition
{
	[StaticGameDataDefinitionId]
	public string key;

	public string gp_sku;

	public string apple_sku;

	public string csg_id;

	public string duration;

	public string trial;

	public bool is_recurring;
}
