// OutfitTagMatcher2
using ClubPenguin.Tags;
using System;
using UnityEngine;

[Serializable]
public class OutfitTagMatcher2 : BaseOutfitTagMatcher, ITagMatcher
{
	[SerializeField]
	private OutfitTagMatcher3[] matchers;

	public BaseTagMatcher[] Matchers => matchers;
}
