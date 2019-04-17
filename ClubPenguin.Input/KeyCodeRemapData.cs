// KeyCodeRemapData
using ClubPenguin.Input;
using System;
using UnityEngine;

public class KeyCodeRemapData : ScriptableObject
{
	[Serializable]
	public struct KeyCodeRemap
	{
		public KeyCode KeyCode;

		public KeyCode RemappedKeyCode;
	}

	public KeyCodeRemap[] KeyCodeRemaps = new KeyCodeRemap[0];
}
