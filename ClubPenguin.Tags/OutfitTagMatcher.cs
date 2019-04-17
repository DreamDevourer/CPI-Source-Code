// OutfitTagMatcher
using ClubPenguin.Tags;
using System;
using UnityEngine;

[Serializable]
public class OutfitTagMatcher : BaseOutfitTagMatcher, ITagMatcher
{
	[SerializeField]
	private OutfitTagMatcher2[] matchers;

	public BaseTagMatcher[] Matchers => matchers;
}
