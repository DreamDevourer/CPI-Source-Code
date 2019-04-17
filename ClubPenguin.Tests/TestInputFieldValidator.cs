// TestInputFieldValidator
using ClubPenguin.UI;

public class TestInputFieldValidator : InputFieldValidator
{
	public void StartTest(string testString)
	{
		TextInput.text = testString;
		StartValidation();
	}
}
