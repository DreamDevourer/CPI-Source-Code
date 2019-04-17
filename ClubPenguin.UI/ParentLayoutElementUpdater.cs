// ParentLayoutElementUpdater
using Disney.Kelowna.Common;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ParentLayoutElementUpdater : MonoBehaviour
{
	public LayoutGroup SourceLayoutGroup;

	private LayoutElement parentLayoutElement;

	private void OnEnable()
	{
		CoroutineRunner.Start(waitForParent(), this, "waitForParent");
	}

	private IEnumerator waitForParent()
	{
		while (base.transform.parent == null || base.transform.parent.GetComponent<LayoutElement>() == null)
		{
			yield return null;
		}
		parentLayoutElement = base.transform.parent.GetComponent<LayoutElement>();
		CoroutineRunner.Start(waitForLayout(), this, "waitForLayout");
	}

	private IEnumerator waitForLayout()
	{
		while (Mathf.Abs(SourceLayoutGroup.preferredWidth) < 1.401298E-45f || Mathf.Abs(SourceLayoutGroup.preferredHeight) < 1.401298E-45f)
		{
			yield return null;
		}
		parentLayoutElement.preferredWidth = SourceLayoutGroup.preferredWidth;
		parentLayoutElement.preferredHeight = SourceLayoutGroup.preferredHeight;
	}

	private void OnDisable()
	{
		CoroutineRunner.StopAllForOwner(this);
		parentLayoutElement = null;
	}
}
