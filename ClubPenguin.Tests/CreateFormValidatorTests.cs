// CreateFormValidatorTests
using ClubPenguin.Mix;
using ClubPenguin.Tests;
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using Disney.Kelowna.Common.Tests;
using Disney.MobileNetwork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFormValidatorTests : BaseLoginCreateIntegrationTest
{
	public InputFieldValidator UsernameTestInputField;

	public GameObject UsernameErrorObject;

	private List<FieldTestData> usernameTests = new List<FieldTestData>();

	public InputFieldValidator PasswordTestInputField;

	public GameObject PasswordErrorObject;

	private List<FieldTestData> passwordTests = new List<FieldTestData>();

	public InputFieldValidator ParentEmailTestInputField;

	public GameObject ParentEmailErrorObject;

	private List<FieldTestData> parentEmailTests = new List<FieldTestData>();

	public InputFieldValidator FirstNameTestInputField;

	public GameObject FirstNameErrorObject;

	private List<FieldTestData> firstNameTests = new List<FieldTestData>();

	protected override IEnumerator runTest()
	{
		IntegrationTestEx.FailIf(Service.Get<MixLoginCreateService>().NetworkConfigIsNotSet);
		yield return StartCoroutine(base.runTest());
		usernameTests.Add(new FieldTestData("", shouldTriggerError: true, "Empty Username"));
		usernameTests.Add(new FieldTestData("hCxRS", shouldTriggerError: true, "Too Short Boundary (5 char long) Username"));
		usernameTests.Add(new FieldTestData("VBZkEZ", shouldTriggerError: false, "Too Short Boundary (6 char long) Username"));
		usernameTests.Add(new FieldTestData("9VigZMl", shouldTriggerError: false, "Too Short Boundary (7 char long) Username"));
		usernameTests.Add(new FieldTestData("K4fR0VfK4MToQslVupGkGvAKFqw3HBXOfkpXalYUX1Kv5kbKL08MNxk3W2gfjk0", shouldTriggerError: false, "Too Long Boundary (63 char long) Username"));
		usernameTests.Add(new FieldTestData("T3uyzjtGIcoHGmNeW2sO3ikBN9rgiX3oNiMCnJ6Wc3CmqxCBxtNqMICsF4bvLDDE", shouldTriggerError: false, "Too Long Boundary (64 char long) Username"));
		usernameTests.Add(new FieldTestData("EhqzerN6iee3cfH1AMrOvmCuUPHWwv3B69SbEMmqs3JHaC8CuYqgtmtxuD6Oyeeql", shouldTriggerError: true, "Too Long Boundary (65 char long) Username"));
		usernameTests.Add(new FieldTestData("hellos!", shouldTriggerError: true, "Invalid Username"));
		usernameTests.Add(new FieldTestData("dtdevmouse", shouldTriggerError: true, "Already Used Username"));
		passwordTests.Add(new FieldTestData("", shouldTriggerError: true, "Empty Password"));
		passwordTests.Add(new FieldTestData("hC5RS", shouldTriggerError: true, "Too Short Boundary (5 char long) Password"));
		passwordTests.Add(new FieldTestData("VB7kEZ", shouldTriggerError: false, "Too Short Boundary (6 char long) Password"));
		passwordTests.Add(new FieldTestData("9VigZMl", shouldTriggerError: false, "Too Short Boundary (7 char long) Password"));
		passwordTests.Add(new FieldTestData("ZiRs5plO0IuyNYvhxgJrOoYn", shouldTriggerError: false, "Too Long Boundary (24 char long) Password"));
		passwordTests.Add(new FieldTestData("WzhKs5aQyWinszrtxEuGE3x", shouldTriggerError: false, "Too Long Boundary (23 char long) Password"));
		passwordTests.Add(new FieldTestData("BagF4FBSZSjsZeKBpetLpOj9M", shouldTriggerError: true, "Too Long Boundary (25 char long)Password"));
		passwordTests.Add(new FieldTestData("aVigZM", shouldTriggerError: true, "No Numbers or Special Chars Used Password"));
		passwordTests.Add(new FieldTestData("123#4%", shouldTriggerError: true, "No Letters Used Password"));
		passwordTests.Add(new FieldTestData("250555555", shouldTriggerError: true, "Includes Phone Number only Password"));
		passwordTests.Add(new FieldTestData("9VigZM(250)555555", shouldTriggerError: true, "Includes Phone Number at end Password"));
		passwordTests.Add(new FieldTestData("250-555.5559VigZM", shouldTriggerError: true, "Includes Phone Number at begining Password"));
		passwordTests.Add(new FieldTestData("VB7kEZ250 555 5559VigZM", shouldTriggerError: true, "Includes Phone Number in middle Password"));
		passwordTests.Add(new FieldTestData("password", shouldTriggerError: true, "Common Password"));
		passwordTests.Add(new FieldTestData(" 9VigZM", shouldTriggerError: true, "Space at begining of Password"));
		passwordTests.Add(new FieldTestData("9VigZM ", shouldTriggerError: true, "Space at end of Password"));
		passwordTests.Add(new FieldTestData("hellos!", shouldTriggerError: true, "Invalid Password"));
		parentEmailTests.Add(new FieldTestData("", shouldTriggerError: true, "Empty Parent Email"));
		parentEmailTests.Add(new FieldTestData("@email.com", shouldTriggerError: true, "Invalid Parent Email"));
		parentEmailTests.Add(new FieldTestData("email", shouldTriggerError: true, "Invalid Parent Email"));
		parentEmailTests.Add(new FieldTestData("@com", shouldTriggerError: true, "Invalid Parent Email"));
		parentEmailTests.Add(new FieldTestData("email.email@com", shouldTriggerError: true, "Invalid Parent Email"));
		firstNameTests.Add(new FieldTestData("", shouldTriggerError: true, "Empty First Name"));
		foreach (FieldTestData passwordTest in passwordTests)
		{
			foreach (FieldTestData usernameTest in usernameTests)
			{
				foreach (FieldTestData parentEmailTest in parentEmailTests)
				{
					foreach (FieldTestData firstNameTest in firstNameTests)
					{
						yield return StartCoroutine(testStep(usernameTest, passwordTest, parentEmailTest, firstNameTest));
					}
				}
			}
		}
	}

	protected IEnumerator testStep(FieldTestData usernameTest, FieldTestData passwordTest, FieldTestData parentemailTest, FieldTestData firstnameTest)
	{
		UsernameTestInputField.TextInput.text = usernameTest.InputValue;
		UsernameTestInputField.TextInput.onEndEdit.Invoke(usernameTest.InputValue);
		yield return new WaitForEndOfFrame();
		PasswordTestInputField.TextInput.text = passwordTest.InputValue;
		PasswordTestInputField.TextInput.onEndEdit.Invoke(passwordTest.InputValue);
		yield return new WaitForEndOfFrame();
		ParentEmailTestInputField.TextInput.text = parentemailTest.InputValue;
		ParentEmailTestInputField.TextInput.onEndEdit.Invoke(parentemailTest.InputValue);
		yield return new WaitForEndOfFrame();
		FirstNameTestInputField.TextInput.text = firstnameTest.InputValue;
		FirstNameTestInputField.TextInput.onEndEdit.Invoke(firstnameTest.InputValue);
		yield return new WaitForEndOfFrame();
		while (!UsernameTestInputField.IsValidationComplete && !PasswordTestInputField.IsValidationComplete && !ParentEmailTestInputField.IsValidationComplete && !FirstNameTestInputField.IsValidationComplete)
		{
			yield return null;
		}
		bool errorsFound = false;
		string message = "";
		if (UsernameTestInputField.HasError != usernameTest.ShouldTriggerError || UsernameErrorObject.activeInHierarchy != usernameTest.ShouldTriggerError)
		{
			errorsFound = true;
			string text = message;
			message = text + usernameTest.Message + "(" + usernameTest.InputValue + ") Failed \n";
		}
		if (PasswordTestInputField.HasError != passwordTest.ShouldTriggerError || PasswordErrorObject.activeInHierarchy != passwordTest.ShouldTriggerError)
		{
			errorsFound = true;
			string text = message;
			message = text + passwordTest.Message + "(" + passwordTest.InputValue + ") Failed \n";
		}
		if (ParentEmailTestInputField.HasError != parentemailTest.ShouldTriggerError || ParentEmailErrorObject.activeInHierarchy != parentemailTest.ShouldTriggerError)
		{
			errorsFound = true;
			string text = message;
			message = text + parentemailTest.Message + "(" + parentemailTest.InputValue + ") Failed \n";
		}
		if (FirstNameTestInputField.HasError != firstnameTest.ShouldTriggerError || FirstNameErrorObject.activeInHierarchy != firstnameTest.ShouldTriggerError)
		{
			errorsFound = true;
			string text = message;
			message = text + firstnameTest.Message + "(" + firstnameTest.InputValue + ") Failed \n";
		}
		IntegrationTestEx.FailIf(errorsFound, message);
	}

	protected override void tearDown()
	{
	}
}
