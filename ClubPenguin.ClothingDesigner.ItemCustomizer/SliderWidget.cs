// SliderWidget
using ClubPenguin.ClothingDesigner.ItemCustomizer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderWidget : Slider
{
	private GameObject _disabledCover = null;

	private bool _hasInput = false;

	protected override void Awake()
	{
		base.Awake();
		Transform transform = base.transform.parent.Find("_disabledCover");
		if (transform != null)
		{
			_disabledCover = transform.gameObject;
		}
	}

	public void SetInteractable(bool isInteractable)
	{
		bool flag = true;
		if (!isInteractable && _hasInput)
		{
			flag = false;
		}
		if (flag)
		{
			base.interactable = isInteractable;
			if (_disabledCover != null)
			{
				_disabledCover.SetActive(!base.interactable);
			}
		}
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		if (IsInteractable())
		{
			base.OnPointerDown(eventData);
			_hasInput = true;
			CustomizationContext.EventBus.DispatchEvent(new CustomizerUIEvents.InputStateChange(isDown: true, isManipulator: true));
		}
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		if (IsInteractable())
		{
			base.OnPointerUp(eventData);
			_hasInput = false;
			CustomizationContext.EventBus.DispatchEvent(new CustomizerUIEvents.InputStateChange(isDown: false, isManipulator: true));
		}
	}
}
