// HorizontalOpenCloseTweener
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class HorizontalOpenCloseTweener : OpenCloseTweener
{
	public bool StartsOpen;

	private RectTransform Content;

	private void Start()
	{
		Content = (base.transform as RectTransform);
		Content.gameObject.SetActive(value: false);
		CoroutineRunner.Start(waitForLayout(), this, "waitForLayout");
	}

	private IEnumerator waitForLayout()
	{
		while (Math.Abs(Content.rect.width) < 1.401298E-45f)
		{
			yield return null;
		}
		float openPosition = 0f;
		float closedPosition = 0f - Content.rect.width;
		Init(openPosition, closedPosition);
		if (StartsOpen)
		{
			SetOpen();
		}
		else
		{
			SetClosed();
		}
		Content.gameObject.SetActive(value: true);
	}

	protected override void setPosition(float value)
	{
		Vector2 anchoredPosition = Content.anchoredPosition;
		anchoredPosition.x = value;
		Content.anchoredPosition = anchoredPosition;
	}
}
