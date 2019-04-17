// PasswordFieldValidatorTests
using ClubPenguin.Tests;
using System.Collections;

public class PasswordFieldValidatorTests : FormFieldValidatorTests
{
	protected override IEnumerator runTest()
	{
		yield return StartCoroutine(base.runTest());
		yield return StartCoroutine(testStep("", shouldSeeError: true, "Empty Password"));
		yield return StartCoroutine(testStep("hC5RS", shouldSeeError: true, "Too Short Boundary (5 char long) Password"));
		yield return StartCoroutine(testStep("VB7kEZ", shouldSeeError: false, "Too Short Boundary (6 char long) Password"));
		yield return StartCoroutine(testStep("9VigZMl", shouldSeeError: false, "Too Short Boundary (7 char long) Password"));
		yield return StartCoroutine(testStep("WzhKs5aQyWinszrtxEuGE3xa", shouldSeeError: false, "Too Long Boundary (24 char long) Password"));
		yield return StartCoroutine(testStep("ZiRs5plO0IuyNYvhxgJrOoYnb", shouldSeeError: false, "Too Long Boundary (25 char long) Password"));
		yield return StartCoroutine(testStep("BagF4FBSZSjsZeKBpetLpOj9Mc", shouldSeeError: true, "Too Long Boundary (26 char long)Password"));
		yield return StartCoroutine(testStep(" 9VigZM", shouldSeeError: true, "Space at begining of Password"));
		yield return StartCoroutine(testStep("9VigZM ", shouldSeeError: true, "Space at end of Password"));
		yield return StartCoroutine(testStep("aVigZM", shouldSeeError: true, "No Numbers or Special Chars Used Password"));
		yield return StartCoroutine(testStep("123#4%", shouldSeeError: true, "No Letters Used Password"));
		yield return StartCoroutine(testStep("password1", shouldSeeError: true, "Common Password"));
		yield return StartCoroutine(testStep("123qwe", shouldSeeError: true, "Common Password"));
		yield return StartCoroutine(testStep("123qwerasd", shouldSeeError: true, "Password cannot be phone number"));
	}
}
