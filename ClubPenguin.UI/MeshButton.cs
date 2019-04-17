// MeshButton
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MeshButton : MonoBehaviour
{
	public Camera mainCamera;

	private Collider buttonCollider;

	public bool IsInteractable
	{
		get;
		set;
	}

	public event Action OnClick;

	private void Awake()
	{
		IsInteractable = true;
		buttonCollider = GetComponent<Collider>();
	}

	private void Update()
	{
		if (IsInteractable && Input.GetMouseButtonDown(0))
		{
			CheckHit(Input.mousePosition);
		}
	}

	private void CheckHit(Vector3 position)
	{
		if (buttonCollider.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit _, 100f))
		{
			onClick();
		}
	}

	private void onClick()
	{
		if (this.OnClick != null)
		{
			this.OnClick();
		}
	}
}
