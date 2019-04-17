// ShowCaptchaCommand
using ClubPenguin.Net.Domain;
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using UnityEngine;

public class ShowCaptchaCommand
{
	private readonly PrefabContentKey captchaUIContentKey = new PrefabContentKey("CaptchaPrefabs/CaptchaPrompt");

	public void Execute(CaptchaType captchaType, int? width = default(int?), int? height = default(int?))
	{
		Content.LoadAsync(delegate(string path, GameObject prefab)
		{
			onCaptchaUILoaded(prefab, captchaType, width, height);
		}, captchaUIContentKey);
	}

	private void onCaptchaUILoaded(GameObject captchaPrefab, CaptchaType captchaType, int? width = default(int?), int? height = default(int?))
	{
		GameObject gameObject = Object.Instantiate(captchaPrefab);
		CaptchaController component = gameObject.GetComponent<CaptchaController>();
		component.SetupCaptcha(captchaType, width, height);
	}
}
