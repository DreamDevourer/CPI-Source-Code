// TagsData
using ClubPenguin.Core;
using ClubPenguin.Tags;
using UnityEngine;

public class TagsData : MonoBehaviour
{
	public TagsArray[] Data;

	public void SetTags(TagDefinition[][] definitions)
	{
		Data = new TagsArray[definitions.Length];
		for (int i = 0; i < definitions.Length; i++)
		{
			Data[i] = new TagsArray(definitions[i]);
		}
	}
}
