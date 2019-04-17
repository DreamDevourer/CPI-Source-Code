// InputLib
using ClubPenguin.Input;
using UnityEngine;

public abstract class InputLib : ScriptableObject
{
	public abstract void Initialize(KeyCodeRemapper keyCodeRemapper);

	public abstract void StartFrame();

	public abstract void EndFrame();
}
