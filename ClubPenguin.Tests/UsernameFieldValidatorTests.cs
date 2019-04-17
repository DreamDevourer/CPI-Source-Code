// UsernameFieldValidatorTests
using ClubPenguin.Tests;
using System.Collections;

public class UsernameFieldValidatorTests : FormFieldValidatorTests
{
	protected override IEnumerator runTest()
	{
		yield return StartCoroutine(base.runTest());
		yield return StartCoroutine(testStep("", shouldSeeError: true, "Empty Username"));
		yield return StartCoroutine(testStep("hCx", shouldSeeError: true, "Too Short Boundary (3 char long) Username"));
		yield return StartCoroutine(testStep("VBZk", shouldSeeError: false, "Too Short Boundary (4 char long) Username"));
		yield return StartCoroutine(testStep("9ViMl", shouldSeeError: false, "Too Short Boundary (5 char long) Username"));
		yield return StartCoroutine(testStep("K4fR0VfK4MToQslVupGkGvAKFqw3HBXOfkpXalYUX1Kv5kbKL08MNxk3W2gfjk0", shouldSeeError: false, "Too Long Boundary (63 char long) Username"));
		yield return StartCoroutine(testStep("T3uyzjtGIcoHGmNeW2sO3ikBN9rgiX3oNiMCnJ6Wc3CmqxCBxtNqMICsF4bvLDDE", shouldSeeError: false, "Too Long Boundary (64 char long) Username"));
		yield return StartCoroutine(testStep("EhqzerN6iee3cfH1AMrOvmCuUPHWwv3B69SbEMmqs3JHaC8CuYqgtmtxuD6Oyeeql", shouldSeeError: true, "Too Long Boundary (65 char long) Username"));
		yield return StartCoroutine(testStep("abcdefghij41", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("klmnopqrst32", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("uvwxyzABCD56", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("EFGHIJCLMN78", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("OPQRSTUVWX90", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("YZŒœßÀÁÂÃÄ1", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("ÆÇÈÉÊËÌÍÎÏ2", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("ÑÒÓÔÕÖÙÚÛÜù3", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("Ýàáâãäæçèéõ4", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("úûüýîïñòóôö5", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("êëìí397", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("АБВГДЕЖЗИЙ01", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("КЛМНОПРСТУ23", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("ФХЦЧШЩЪЫЬЭ45", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("ЮЯабвгдежз67", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("ийклмнопрс89", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("туфхцчшщъыь", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("эюяЁё635", shouldSeeError: false, "CP Valid Char Check Username"));
		yield return StartCoroutine(testStep("Danielle[", shouldSeeError: true, "Invalid Contains ["));
		yield return StartCoroutine(testStep("Dani]elle", shouldSeeError: true, "Invalid Contains ]"));
		yield return StartCoroutine(testStep("Danielle}", shouldSeeError: true, "Invalid Contains }"));
		yield return StartCoroutine(testStep("Dani{elle", shouldSeeError: true, "Invalid Contains {"));
		yield return StartCoroutine(testStep("Danielle|I", shouldSeeError: true, "Invalid |"));
		yield return StartCoroutine(testStep("Danielle&I", shouldSeeError: true, "Invalid &"));
		yield return StartCoroutine(testStep("Danielle%20", shouldSeeError: true, "Invalid %"));
		yield return StartCoroutine(testStep("Danielle<I", shouldSeeError: true, "Invalid <"));
		yield return StartCoroutine(testStep("Danielle>20", shouldSeeError: true, "Invalid >"));
		yield return StartCoroutine(testStep("<script>alert('Danielle');</script>", shouldSeeError: true, "Invalid XSS"));
		yield return StartCoroutine(testStep("dtdevmouse", shouldSeeError: true, "Already Used Username"));
	}
}
