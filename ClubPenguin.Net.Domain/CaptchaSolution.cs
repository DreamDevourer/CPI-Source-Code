// CaptchaSolution
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class CaptchaSolution
{
	public string id;

	public CaptchaDimensions captchaDimensions;

	public List<SolutionPoint> solution;
}
