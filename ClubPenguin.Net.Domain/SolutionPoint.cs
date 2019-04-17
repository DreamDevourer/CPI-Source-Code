// SolutionPoint
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class SolutionPoint
{
	public int x;

	public int y;

	public CaptchaOrigin origin = CaptchaOrigin.BOTTOM_LEFT;
}
