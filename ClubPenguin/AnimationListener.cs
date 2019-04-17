// AnimationListener
using UnityEngine;
using UnityEngine.Events;

public class AnimationListener : MonoBehaviour
{
	public UnityEvent Listener;

	public void OnAnimationEventDispatched()
	{
		Listener.Invoke();
	}
}
