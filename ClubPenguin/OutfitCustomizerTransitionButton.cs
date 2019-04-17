// OutfitCustomizerTransitionButton
using ClubPenguin;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OutfitCustomizerTransitionButton : MonoBehaviour
{
	public const string INVENTORY_SCENE = "ClothingDesigner";

	public string LoadingScene = "Loading";

	private Button button;

	public void Awake()
	{
		button = GetComponent<Button>();
	}

	public void OnEnable()
	{
		button.onClick.AddListener(Load);
	}

	public void OnDisable()
	{
		button.onClick.RemoveListener(Load);
	}

	public virtual void Load()
	{
		Service.Get<SceneTransitionService>().LoadScene("ClothingDesigner", LoadingScene);
	}
}
