// PointerDownButton
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerDownButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public UnityEvent OnClick;

	public void OnPointerDown(PointerEventData eventData)
	{
		OnClick.Invoke();
	}
}
