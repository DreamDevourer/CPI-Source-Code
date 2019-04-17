// HeldObjectsData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class HeldObjectsData : BaseData
{
	[SerializeField]
	private DHeldObject heldObject;

	[SerializeField]
	private bool isInvitationalExperience = false;

	public bool IsInvitationalExperience
	{
		get
		{
			return isInvitationalExperience;
		}
		set
		{
			isInvitationalExperience = value;
		}
	}

	public DHeldObject HeldObject
	{
		get
		{
			return heldObject;
		}
		set
		{
			if (heldObject != value)
			{
				changedHeldObject(value);
				heldObject = value;
				isInvitationalExperience = false;
			}
		}
	}

	protected override Type monoBehaviourType => typeof(HeldObjectsDataMonoBehaviour);

	public event Action<DHeldObject> PlayerHeldObjectChanged;

	protected override void notifyWillBeDestroyed()
	{
		this.PlayerHeldObjectChanged = null;
	}

	private void changedHeldObject(DHeldObject obj)
	{
		if (this.PlayerHeldObjectChanged != null)
		{
			this.PlayerHeldObjectChanged(obj);
		}
	}
}
