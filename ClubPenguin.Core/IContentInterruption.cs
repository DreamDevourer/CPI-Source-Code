// IContentInterruption
using System;
using UnityEngine;

public interface IContentInterruption
{
	event Action OnReturn;

	event Action OnContinue;

	void Show(Transform parentTransform = null);
}
