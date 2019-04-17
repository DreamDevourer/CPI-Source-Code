// DecalButton
using ClubPenguin.ClothingDesigner.ItemCustomizer;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DecalButton : MonoBehaviour
{
	public Image IconImage;

	public Texture2D decalTexture;

	public void SetModel(DItemCustomization itemModel)
	{
	}

	public void Select()
	{
	}

	public void Deselect()
	{
	}

	public void SetDecalIconTexture(Texture2D texture)
	{
		decalTexture = texture;
		IconImage.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), default(Vector2));
	}
}
