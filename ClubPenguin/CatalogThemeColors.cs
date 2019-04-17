// CatalogThemeColors
using ClubPenguin;
using Disney.MobileNetwork;
using System;
using UnityEngine;

public class CatalogThemeColors
{
	private DateTime startDate;

	public Color[] foreground
	{
		get;
		private set;
	}

	public Color[] background
	{
		get;
		private set;
	}

	public int indexOffset
	{
		get;
		private set;
	}

	public CatalogThemeColors()
	{
		startDate = new DateTime(2017, 2, 21, 0, 0, 0);
		foreground = new Color[7]
		{
			new Color(0.647058845f, 0.1764706f, 0.5764706f),
			new Color(0.6745098f, 0.0470588244f, 0.07450981f),
			new Color(0.721568644f, 0.321568638f, 0f),
			new Color(0.294117659f, 0.5568628f, 0.0196078438f),
			new Color(0.1254902f, 0.4117647f, 0.572549045f),
			new Color(0.168627456f, 0.623529434f, 1f),
			new Color(0.5137255f, 0.396078438f, 0.9372549f)
		};
		background = new Color[7]
		{
			new Color(0.847058833f, 0.2901961f, 0.7647059f),
			new Color(0.921568632f, 0.2627451f, 0.294117659f),
			new Color(0.921568632f, 0.5254902f, 0.0235294122f),
			new Color(0.6509804f, 0.827451f, 0.223529413f),
			new Color(0.447058827f, 0.7647059f, 1f),
			new Color(0f, 0.423529416f, 0.7764706f),
			new Color(0.3019608f, 0.184313729f, 0.7411765f)
		};
	}

	public void SetIndex()
	{
		calculateIndexOffset(Service.Get<ContentSchedulerService>().PresentTime());
	}

	public void SetIndex(DateTime overrideDateTime)
	{
		calculateIndexOffset(overrideDateTime);
	}

	private void calculateIndexOffset(DateTime dateTime)
	{
		for (indexOffset = (dateTime - startDate).Days; indexOffset >= foreground.Length; indexOffset -= foreground.Length)
		{
		}
	}

	public Color[] GetColorsByIndex(int index)
	{
		if (index < 0)
		{
			index = 0;
		}
		while (index >= foreground.Length)
		{
			index -= foreground.Length;
		}
		index -= indexOffset;
		if (index < 0)
		{
			index = foreground.Length + index;
		}
		return new Color[2]
		{
			foreground[index],
			background[index]
		};
	}
}
