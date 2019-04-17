// AvatarRenderTextureRotator
using ClubPenguin.Cinematography;
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

[RequireComponent(typeof(AvatarRenderTextureComponent))]
public class AvatarRenderTextureRotator : MonoBehaviour
{
	public RectTransform TouchArea;

	public float RotationSpeed = 15f;

	private AvatarRenderTextureComponent renderTextureComponent;

	private float previousTouchX;

	private bool isRotating;

	private void Awake()
	{
		renderTextureComponent = GetComponent<AvatarRenderTextureComponent>();
	}

	private void Start()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(CinematographyEvents.DisableElasticGlancer));
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (TouchArea == null || RectTransformUtility.RectangleContainsScreenPoint(TouchArea, Input.mousePosition))
			{
				isRotating = true;
				previousTouchX = Input.mousePosition.x;
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			isRotating = false;
		}
		else if (Input.GetMouseButton(0) && isRotating)
		{
			float num = Input.mousePosition.x - previousTouchX;
			renderTextureComponent.RotateModel((0f - num) * RotationSpeed);
			previousTouchX = Input.mousePosition.x;
		}
	}

	private void OnDestroy()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(CinematographyEvents.EnableElasticGlancer));
	}
}
