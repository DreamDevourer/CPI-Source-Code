// CustomGraphicsService
using ClubPenguin;
using ClubPenguin.Configuration;
using Disney.Kelowna.Common;
using Disney.MobileNetwork;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomGraphicsService
{
	public int AntiAliasSamplesMedium = 4;

	public int AntiAliasSamplesHigh = 4;

	public readonly Dictionary<string, float> SupportedAspectRatios = new Dictionary<string, float>
	{
		{
			"16:9",
			1.77777779f
		},
		{
			"5:3",
			1.66666663f
		},
		{
			"16:10",
			1.6f
		},
		{
			"4:3",
			1.33333337f
		}
	};

	public readonly Dictionary<string, ClubPenguin.QualityLevel> QualityLevelByConditionalTier = new Dictionary<string, ClubPenguin.QualityLevel>
	{
		{
			"Mobile_Low",
			ClubPenguin.QualityLevel.Low
		},
		{
			"Mobile_Medium",
			ClubPenguin.QualityLevel.Low
		},
		{
			"Mobile_High",
			ClubPenguin.QualityLevel.Low
		},
		{
			"Standalone_Low",
			ClubPenguin.QualityLevel.Low
		},
		{
			"Standalone_Medium",
			ClubPenguin.QualityLevel.Medium
		},
		{
			"Standalone_High",
			ClubPenguin.QualityLevel.High
		},
		{
			"Default",
			ClubPenguin.QualityLevel.Low
		}
	};

	public static float AspectRatio
	{
		get;
		private set;
	}

	public static string AspectAlias
	{
		get;
		private set;
	}

	public CacheableType<string> QualityConditionalTier
	{
		get;
		private set;
	}

	public CacheableType<ClubPenguin.QualityLevel> GraphicsLevel
	{
		get;
		private set;
	}

	public CacheableType<ClubPenguin.QualityLevel> LodPenguinQualityLevel
	{
		get;
		private set;
	}

	public CacheableType<int> AntiAliasLevel
	{
		get;
		private set;
	}

	public CacheableType<bool> CameraPostEnabled
	{
		get;
		private set;
	}

	public void Init()
	{
		string text = Service.Get<ConditionalConfiguration>().Get("Unity.QualitySetting.property", "Mobile_Low");
		getDefaultGraphicsValues(text, out ClubPenguin.QualityLevel graphicsLevel, out ClubPenguin.QualityLevel lodPenguinQualityLevel, out int antiAlias, out bool cameraPost);
		QualityConditionalTier = new CacheableType<string>("cp.QualityConditionalTier", text);
		GraphicsLevel = new CacheableType<ClubPenguin.QualityLevel>("cp.GraphicsLevel", graphicsLevel);
		LodPenguinQualityLevel = new CacheableType<ClubPenguin.QualityLevel>("cp.LodPenguinQualityLevel", lodPenguinQualityLevel);
		AntiAliasLevel = new CacheableType<int>("cp.AntiAliasEnabled", antiAlias);
		CameraPostEnabled = new CacheableType<bool>("cp.CameraPostenabled", cameraPost);
		GameSettings gameSettings = Service.Get<GameSettings>();
		gameSettings.RegisterSetting(QualityConditionalTier, canBeReset: true);
		gameSettings.RegisterSetting(GraphicsLevel, canBeReset: true);
		gameSettings.RegisterSetting(LodPenguinQualityLevel, canBeReset: true);
		gameSettings.RegisterSetting(AntiAliasLevel, canBeReset: true);
		gameSettings.RegisterSetting(CameraPostEnabled, canBeReset: true);
		SetAntialiasing(AntiAliasLevel);
		SetCameraPostEffects(CameraPostEnabled);
		SetLodPenguinQualityLevel(LodPenguinQualityLevel);
		SetFullscreen(Screen.fullScreen);
		SetAspectRatio((float)Screen.width / (float)Screen.height);
		if (AspectAlias == string.Empty)
		{
			SetAspectRatio(1.77777779f);
		}
	}

	private void getDefaultGraphicsValues(string qualityName, out ClubPenguin.QualityLevel graphicsLevel, out ClubPenguin.QualityLevel lodPenguinQualityLevel, out int antiAlias, out bool cameraPost)
	{
		if (QualityLevelByConditionalTier.TryGetValue(qualityName, out graphicsLevel))
		{
			switch (graphicsLevel)
			{
			case ClubPenguin.QualityLevel.Low:
				antiAlias = 0;
				cameraPost = false;
				break;
			case ClubPenguin.QualityLevel.Medium:
				antiAlias = AntiAliasSamplesMedium;
				cameraPost = false;
				break;
			case ClubPenguin.QualityLevel.High:
				antiAlias = AntiAliasSamplesHigh;
				cameraPost = true;
				break;
			default:
				antiAlias = 0;
				cameraPost = false;
				break;
			}
			lodPenguinQualityLevel = graphicsLevel;
		}
		else
		{
			graphicsLevel = ClubPenguin.QualityLevel.High;
			lodPenguinQualityLevel = graphicsLevel;
			antiAlias = AntiAliasSamplesHigh;
			cameraPost = true;
		}
	}

	public void SetGraphicsLevel(string qualityName)
	{
		if (QualityLevelByConditionalTier.TryGetValue(qualityName, out ClubPenguin.QualityLevel value))
		{
			setQualityLevel(qualityName);
			switch (value)
			{
			case ClubPenguin.QualityLevel.High:
				SetAntialiasing(AntiAliasSamplesHigh);
				SetCameraPostEffects(value: true);
				break;
			case ClubPenguin.QualityLevel.Medium:
				SetAntialiasing(AntiAliasSamplesMedium);
				SetCameraPostEffects(value: false);
				break;
			case ClubPenguin.QualityLevel.Low:
				SetAntialiasing(0);
				SetCameraPostEffects(value: false);
				break;
			}
			SetLodPenguinQualityLevel(value);
			GraphicsLevel.SetValue(value);
		}
		else
		{
			setQualityLevel("Default");
			SetAntialiasing(0);
			SetCameraPostEffects(value: false);
		}
	}

	private void setQualityLevel(string qualityName)
	{
		int num = 0;
		while (true)
		{
			if (num < QualitySettings.names.Length)
			{
				if (QualitySettings.names[num].Equals(qualityName, StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		QualitySettings.SetQualityLevel(num, applyExpensiveChanges: true);
		QualityConditionalTier.SetValue(qualityName);
	}

	public void SetAntialiasing(int samples)
	{
		QualitySettings.antiAliasing = samples;
		AntiAliasLevel.SetValue(samples);
	}

	public void SetCameraPostEffects(bool value)
	{
		CameraPostEnabled.SetValue(value);
	}

	public void SetLodPenguinQualityLevel(ClubPenguin.QualityLevel level)
	{
		LodPenguinQualityLevel.SetValue(level);
	}

	public void SetFullscreen(bool value)
	{
		Screen.fullScreen = value;
		if (!value)
		{
			TryFitWindowedScreen(Screen.width, Screen.height);
		}
	}

	public bool TryFitWindowedScreen(int width, int height)
	{
		int num = (int)((float)Screen.currentResolution.width * 0.99f);
		int num2 = (int)((float)Screen.currentResolution.height * 0.94f);
		int width2 = Math.Min(width, num);
		int height2 = Math.Min(height, num2);
		if (width > num || height > num2)
		{
			DisplayResolutionManager.SetRawResolution(width2, height2, fullscreen: false);
			return false;
		}
		return true;
	}

	public void SetAspectRatio(float ratio)
	{
		AspectRatio = ratio;
		AspectAlias = GetAspectAliasFromRatio(ratio);
	}

	public string GetAspectAliasFromRatio(float ratio)
	{
		if (Mathf.Abs(ratio - 1.77777779f) < 0.01f)
		{
			return "16:9";
		}
		if (Mathf.Abs(ratio - 1.66666663f) < 0.01f)
		{
			return "5:3";
		}
		if (Mathf.Abs(ratio - 1.6f) < 0.01f)
		{
			return "16:10";
		}
		if (Mathf.Abs(ratio - 1.33333337f) < 0.01f)
		{
			return "4:3";
		}
		return string.Empty;
	}
}
