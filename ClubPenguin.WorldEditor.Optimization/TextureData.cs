// TextureData
using System;
using UnityEngine;

[Serializable]
public class TextureData
{
	public string TextureName;

	[Range(0f, 2f)]
	public float Weight = 1f;

	public int SizeInAtlas;

	[Header("Should not be edited by user")]
	public Texture2D Texture;

	public float MinDistance = 3.40282347E+38f;

	public float Ratio = 1f;

	public int ImportedSize;

	public Rect AtlasOffset;
}
