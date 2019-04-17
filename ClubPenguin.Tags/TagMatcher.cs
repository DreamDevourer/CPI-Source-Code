// TagMatcher
using ClubPenguin.Tags;
using System;
using UnityEngine;

[Serializable]
public class TagMatcher : BaseRecursiveTagMatcher
{
	[SerializeField]
	private TagMatcher2[] matchers;

	public override BaseTagMatcher[] Matchers => matchers;
}
