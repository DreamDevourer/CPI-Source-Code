// CollidableObjectCollisionOverrides
using ClubPenguin.ObjectManipulation;
using UnityEngine;

public class CollidableObjectCollisionOverrides : MonoBehaviour
{
	[Tooltip("Colliders used in edit/structure mode, game objects must be disabled")]
	public Collider[] EditModeColliders;

	[Tooltip("Colliders used when the object is selected in edit mode, game objects must be disabled")]
	public Collider[] DraggingColliders;

	private Collider[] defaultColliders;

	public Collider[] DefaultColliders
	{
		set
		{
			defaultColliders = value;
		}
	}

	internal void SetEditting()
	{
		if (EditModeColliders.Length > 0)
		{
			setColliders(defaultColliders, enable: false);
			setColliders(DraggingColliders, enable: false);
			setColliders(EditModeColliders, enable: true);
			GetComponent<CollidableObject>().ReloadColliders();
		}
	}

	internal void SetDragging(bool dragging)
	{
		if (DraggingColliders.Length > 0)
		{
			setColliders(defaultColliders, !dragging);
			setColliders(EditModeColliders, !dragging);
			setColliders(DraggingColliders, dragging);
			GetComponent<CollidableObject>().ReloadColliders();
		}
	}

	internal void SetDefault()
	{
		setColliders(EditModeColliders, enable: false);
		setColliders(DraggingColliders, enable: false);
		setColliders(defaultColliders, enable: true);
		GetComponent<CollidableObject>().ReloadColliders();
	}

	private void setColliders(Collider[] colliders, bool enable)
	{
		int num = colliders.Length;
		for (int i = 0; i < num; i++)
		{
			colliders[i].gameObject.SetActive(enable);
		}
	}
}
