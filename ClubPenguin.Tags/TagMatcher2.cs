// TagMatcher2
using ClubPenguin.Tags;
using System;
using UnityEngine;

[Serializable]
public class TagMatcher2 : BaseRecursiveTagMatcher
{
	[SerializeField]
	private TagMatcher3[] matchers;

	public override BaseTagMatcher[] Matchers => matchers;
}
