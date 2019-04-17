// CreateQuestObject
using ClubPenguin.Adventure;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("Quest")]
public class CreateQuestObject : FsmStateAction
{
	[RequiredField]
	public FsmGameObject Prefab;

	public FsmGameObject SpawnPoint;

	public FsmVector3 Position;

	public FsmVector3 Rotation;

	public FsmVector3 Scale;

	[UIHint(UIHint.Variable)]
	public FsmGameObject StoreObject;

	public override void Reset()
	{
		Prefab = null;
		SpawnPoint = null;
		Position = new FsmVector3
		{
			UseVariable = true
		};
		Rotation = new FsmVector3
		{
			UseVariable = true
		};
		Scale = new FsmVector3
		{
			UseVariable = true
		};
		StoreObject = null;
	}

	public override void OnEnter()
	{
		GameObject value = Prefab.Value;
		if (value != null)
		{
			Vector3 vector = Vector3.zero;
			Vector3 euler = Vector3.up;
			if (SpawnPoint.Value != null)
			{
				vector = SpawnPoint.Value.transform.position;
				if (!Position.IsNone)
				{
					vector += Position.Value;
				}
				euler = ((!Rotation.IsNone) ? Rotation.Value : SpawnPoint.Value.transform.eulerAngles);
			}
			else
			{
				if (!Position.IsNone)
				{
					vector = Position.Value;
				}
				if (!Rotation.IsNone)
				{
					euler = Rotation.Value;
				}
			}
			GameObject gameObject = Object.Instantiate(value, vector, Quaternion.Euler(euler));
			if (!Scale.IsNone)
			{
				gameObject.transform.localScale = Scale.Value;
			}
			Quest activeQuest = Service.Get<QuestService>().ActiveQuest;
			if (activeQuest != null && activeQuest.PrefabInstance != null)
			{
				gameObject.transform.SetParent(activeQuest.PrefabInstance.transform, worldPositionStays: true);
			}
			StoreObject.Value = gameObject;
		}
		Finish();
	}
}
