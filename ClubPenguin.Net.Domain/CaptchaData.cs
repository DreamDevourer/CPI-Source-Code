// CaptchaData
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct CaptchaData
{
	public string id;

	public CaptchaType type;

	public long retryTimestamp;

	public string challengeImageData;

	public string captchaImageData;

	public CaptchaDimensions captchaDimensions;

	public string challengeToken;

	public int solutionSize;

	public byte[] ChallengeImageBytes => Convert.FromBase64String(challengeImageData);

	public byte[] CaptchaImageBytes => Convert.FromBase64String(captchaImageData);
}
