// InputMapHandler<TResult>
using ClubPenguin.Input;
using UnityEngine;

public abstract class InputMapHandler<TResult> : MonoBehaviour where TResult : new()
{
	[SerializeField]
	protected InputMapLib inputMap = null;

	private InputHandlerCallback<TResult> handlerCallback;

	protected virtual void OnValidate()
	{
	}

	protected virtual void Awake()
	{
		handlerCallback = new InputHandlerCallback<TResult>(onHandle, onReset);
	}

	protected virtual void OnEnable()
	{
		((InputMap<TResult>)inputMap).AddHandler(handlerCallback);
	}

	protected virtual void OnDisable()
	{
		((InputMap<TResult>)inputMap).RemoveHandler(handlerCallback);
	}

	protected abstract void onHandle(TResult inputResult);

	protected abstract void onReset();
}
