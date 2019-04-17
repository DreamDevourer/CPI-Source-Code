// ICaptchaService
using ClubPenguin.Net;
using ClubPenguin.Net.Domain;

public interface ICaptchaService : INetworkService
{
	bool BypassCaptcha
	{
		get;
		set;
	}

	void GetCaptcha(CaptchaType type, int? width = default(int?), int? height = default(int?));

	void PostCaptchaSolution(CaptchaType type, CaptchaSolution solution);
}
