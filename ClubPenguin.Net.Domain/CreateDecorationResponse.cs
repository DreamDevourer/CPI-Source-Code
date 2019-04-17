// CreateDecorationResponse
using ClubPenguin.Net.Domain;
using ClubPenguin.Net.Domain.Decoration;
using System;

[Serializable]
public class CreateDecorationResponse : CPResponse
{
	public DecorationId decorationId;

	public PlayerAssets assets;
}
