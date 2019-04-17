// MultipleAnimationListener
using UnityEngine;
using UnityEngine.Events;

public class MultipleAnimationListener : MonoBehaviour
{
	public UnityEvent[] Listeners;

	public void OnAnimationEventDispatched(int index)
	{
		Listeners[index].Invoke();
	}
}
