// FirstNameFieldValidatorTests
using ClubPenguin.Tests;
using System.Collections;

public class FirstNameFieldValidatorTests : FormFieldValidatorTests
{
	protected override IEnumerator runTest()
	{
		yield return StartCoroutine(base.runTest());
		yield return StartCoroutine(testStep("", shouldSeeError: true, "Empty First Name"));
		yield return StartCoroutine(testStep("Danielle[", shouldSeeError: true, "Invalid Contains ["));
		yield return StartCoroutine(testStep("Dani]elle", shouldSeeError: true, "Invalid Contains ]"));
		yield return StartCoroutine(testStep("Danielle}", shouldSeeError: true, "Invalid Contains }"));
		yield return StartCoroutine(testStep("Dani{elle", shouldSeeError: true, "Invalid Contains {"));
		yield return StartCoroutine(testStep("Danielle|I", shouldSeeError: true, "Invalid |"));
		yield return StartCoroutine(testStep("Danielle/20", shouldSeeError: true, "Invalid /"));
		yield return StartCoroutine(testStep("Danielle&I", shouldSeeError: true, "Invalid &"));
		yield return StartCoroutine(testStep("Danielle%20", shouldSeeError: true, "Invalid %"));
		yield return StartCoroutine(testStep("Danielle<I", shouldSeeError: true, "Invalid <"));
		yield return StartCoroutine(testStep("Danielle>20", shouldSeeError: true, "Invalid >"));
		yield return StartCoroutine(testStep("<script>alert('Danielle');</script>", shouldSeeError: true, "Invalid XSS"));
	}
}
