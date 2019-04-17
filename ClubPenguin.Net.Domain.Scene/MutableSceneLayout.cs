// MutableSceneLayout
using ClubPenguin.Net.Domain.Scene;
using System;
using System.Collections.Generic;

[Serializable]
public class MutableSceneLayout
{
	public string name;

	public string zoneId;

	public int lightingId;

	public int musicId;

	public Dictionary<string, string> extraInfo = new Dictionary<string, string>();

	public List<DecorationLayout> decorationsLayout;
}
