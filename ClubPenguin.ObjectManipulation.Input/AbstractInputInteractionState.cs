// AbstractInputInteractionState
using ClubPenguin.ObjectManipulation.Input;
using Disney.Kelowna.Common;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AbstractInputInteractionState
{
	public LayerMask TargetLayerMask = -1;

	protected InteractionState state;

	protected Vector3 lastMousePositionWhenDown = Vector3.zero;

	protected float MinTimeToMoveInput;

	public InteractionState State
	{
		get
		{
			return state;
		}
		private set
		{
		}
	}

	public virtual void EnterState(LayerMask targetLayerMask, float minTimeToMoveInput)
	{
		MinTimeToMoveInput = minTimeToMoveInput;
		TargetLayerMask = targetLayerMask;
	}

	public virtual void ExitState()
	{
	}

	public virtual int Update()
	{
		int num = Input.touchCount;
		if (num == 1)
		{
		}
		if (Input.GetMouseButton(0))
		{
			num = 1;
			if (!EventSystem.current.IsPointerOverGameObject() && !IsScreenPointOverUI(new Vector2(Input.mousePosition.x, Input.mousePosition.y)))
			{
				processOneTouch(TouchEquivalent.FromLeftMouseButton(lastMousePositionWhenDown));
				lastMousePositionWhenDown = Input.mousePosition;
			}
		}
		else if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			processOneTouch(TouchEquivalent.FromLeftMouseButton(lastMousePositionWhenDown));
			lastMousePositionWhenDown = Vector3.zero;
		}
		return num;
	}

	private static bool IsScreenPointOverUI(Vector2 position)
	{
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = position;
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, list);
		return list.Count > 0;
	}

	protected abstract void processOneTouch(TouchEquivalent touch);

	protected GameObject raycastScreenPointToObject(Vector2 screenPosition, LayerMask mask)
	{
		GameObject result = null;
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		if (Physics.Raycast(ray, out RaycastHit hitInfo, float.PositiveInfinity, mask, QueryTriggerInteraction.Collide))
		{
			result = hitInfo.transform.gameObject;
		}
		return result;
	}
}
