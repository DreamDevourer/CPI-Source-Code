// InputHandlerCallback<TResult>
using System;

public struct InputHandlerCallback<TResult>
{
	public readonly Action<TResult> OnHandle;

	public readonly Action OnReset;

	public InputHandlerCallback(Action<TResult> onHandle, Action onReset)
	{
		OnHandle = onHandle;
		OnReset = onReset;
	}
}
