// PlayerHeldItem
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class PlayerHeldItem : CPMMOItem
{
	public string Type;

	public string Properties;

	public override string ToString()
	{
		return $"PlayerHeldItem: {Type}, Properties: {Properties}";
	}
}
