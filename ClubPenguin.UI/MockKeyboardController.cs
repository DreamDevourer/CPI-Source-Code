// MockKeyboardController
using Disney.MobileNetwork;
using Mix.Native;
using UnityEngine;

public class MockKeyboardController : MonoBehaviour
{
	public void HideKeyboard()
	{
		Service.Get<NativeKeyboardManager>().Keyboard.Hide();
	}
}
