// CustomizationButton
using ClubPenguin.Breadcrumbs;
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationButton : MonoBehaviour
{
	public DraggableButtonType DraggableButtonType;

	public int DefinitionId;

	[SerializeField]
	protected Image IconImage;

	[SerializeField]
	protected GameObject LoadingSpinner;

	[SerializeField]
	protected NotificationBreadcrumb breadcrumb;

	public bool CanDrag
	{
		get;
		protected set;
	}

	public Texture2D GetTexture => (IconImage.sprite == null) ? null : IconImage.sprite.texture;

	protected virtual void Awake()
	{
		LoadingSpinner.SetActive(value: true);
		IconImage.gameObject.SetActive(value: false);
	}

	public virtual void Init(Texture2DContentKey customizationAssetKey, PersistentBreadcrumbTypeDefinitionKey breadcrumbIdType, int definitionId, bool canDrag)
	{
		SetupButton(breadcrumbIdType, definitionId, canDrag);
		try
		{
			Content.LoadAsync<Texture2D>(customizationAssetKey.Key, onIconLoaded);
		}
		catch (ArgumentException ex)
		{
			Log.LogException(this, ex);
		}
	}

	protected void SetupButton(PersistentBreadcrumbTypeDefinitionKey breadcrumbIdType, int definitionId, bool canDrag)
	{
		CanDrag = canDrag;
		DefinitionId = definitionId;
		LoadingSpinner.SetActive(value: true);
		IconImage.gameObject.SetActive(value: false);
		breadcrumb.SetBreadcrumbId(breadcrumbIdType, definitionId.ToString());
	}

	private void onIconLoaded(string path, Texture2D icon)
	{
		SetIconTexture(icon);
	}

	protected void SetIconTexture(Texture2D texture)
	{
		if (IconImage.sprite != null)
		{
			UnityEngine.Object.Destroy(IconImage.sprite);
		}
		LoadingSpinner.SetActive(value: false);
		IconImage.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), default(Vector2));
		IconImage.gameObject.SetActive(value: true);
	}

	protected virtual void OnDestroy()
	{
		CoroutineRunner.StopAllForOwner(this);
		UnityEngine.Object.Destroy(IconImage.sprite);
	}
}
