// FreeCameraController
using ClubPenguin;
using ClubPenguin.BlobShadows;
using ClubPenguin.Core;
using ClubPenguin.LOD;
using Disney.Kelowna.Common.DataModel;
using Disney.Kelowna.Common.SEDFSM;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;
using Tweaker.Core;
using Tweaker.UI;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
	private const string LeftHorizontal = "LeftHorizontal";

	private const string LeftVertical = "LeftVertical";

	private const string RightHorizontal = "RightHorizontal";

	private const string RightVertical = "RightVertical";

	private const string LeftTrigger = "LeftTrigger";

	private const string RightTrigger = "RightTrigger";

	private const string LeftBumper = "LeftBumper";

	private const string RightBumper = "RightBumper";

	private const string StartButton = "StartButton";

	private const string BButton = "BButton";

	private const string XButton = "XButton";

	private const string YButton = "YButton";

	private const string DPadLeft = "DPadLeft";

	private const string DPadRight = "DPadRight";

	private const string DPadUp = "DPadUp";

	private const float defaultFOV = 60f;

	public Transform Target;

	public Camera Camera;

	public float XSensitivity = 4f;

	public float YSensitivity = 2f;

	public float ZSensitivity = 2f;

	public float FOVSensitivity = 1f;

	public float XSpeed = 1f;

	public float YSpeed = 0.2f;

	public float ZSpeed = 1f;

	public bool WorldRelativeZMotion;

	public float RotationModifierFOV = 0.8f;

	public float XSpeedModifierFOV = 0.8f;

	public float YSpeedModifierFOV = 0.8f;

	public float ZSpeedModifierFOV = 0.8f;

	private bool wasLeftTriggerPressed;

	private bool wasRightTriggerPressed;

	private StateMachineContext context;

	private BlobShadowCaster blobShadowCaster;

	private GroupCulling groupCulling;

	private Canvas worldChatCanvas;

	private Camera mainCamera;

	private int localPlayerMask;

	private bool isLocalPlayerActive;

	private float yValue
	{
		get
		{
			if (wasLeftTriggerPressed && wasRightTriggerPressed)
			{
				return Input.GetAxis("RightTrigger") - Input.GetAxis("LeftTrigger");
			}
			float num = 0f;
			if (Math.Abs(Input.GetAxis("LeftTrigger")) > 1.401298E-45f)
			{
				num -= Input.GetAxis("LeftTrigger") + 1f;
				wasLeftTriggerPressed = true;
			}
			if (Math.Abs(Input.GetAxis("RightTrigger")) > 1.401298E-45f)
			{
				num += Input.GetAxis("RightTrigger") + 1f;
				wasRightTriggerPressed = true;
			}
			return num;
		}
	}

	private void Start()
	{
		Camera = base.gameObject.AddComponent<Camera>();
		localPlayerMask = LayerMask.NameToLayer("LocalPlayer");
		mainCamera = Camera.main;
		Camera.cullingMask = mainCamera.cullingMask;
		mainCamera.enabled = false;
		base.gameObject.tag = "MainCamera";
		GameObject gameObject = GameObject.FindGameObjectWithTag(UIConstants.Tags.UI_Tray_Root);
		if (gameObject != null)
		{
			context = gameObject.GetComponent<StateMachineContext>();
			context.SendEvent(new ExternalEvent("Root", "noUI"));
		}
		Service.Get<EventDispatcher>().DispatchEvent(default(PlayerNameEvents.HidePlayerNames));
		DataEntityHandle localPlayerHandle = Service.Get<CPDataEntityCollection>().LocalPlayerHandle;
		GameObjectReferenceData component = default(GameObjectReferenceData);
		if (!localPlayerHandle.IsNull && Service.Get<CPDataEntityCollection>().TryGetComponent(localPlayerHandle, out component))
		{
			blobShadowCaster = component.GameObject.GetComponent<BlobShadowCaster>();
		}
		groupCulling = UnityEngine.Object.FindObjectOfType<GroupCulling>();
		if (groupCulling != null)
		{
			groupCulling.enabled = false;
		}
		GameObject gameObject2 = GameObject.Find("WorldChatCanvas");
		if (gameObject2 != null)
		{
			worldChatCanvas = gameObject2.GetComponent<Canvas>();
			if (worldChatCanvas != null)
			{
				worldChatCanvas.worldCamera = Camera;
			}
		}
		setLocalPlayerActive(isActive: false);
	}

	private void Update()
	{
		Target.position += Target.right * Input.GetAxis("LeftHorizontal") * XSpeed * getFOVModification(XSpeedModifierFOV);
		if (WorldRelativeZMotion)
		{
			Vector3 forward = Target.forward;
			forward.y = 0f;
			Target.position -= forward.normalized * Input.GetAxis("LeftVertical") * ZSpeed * getFOVModification(ZSpeedModifierFOV);
		}
		else
		{
			Target.position -= Target.forward * Input.GetAxis("LeftVertical") * ZSpeed * getFOVModification(ZSpeedModifierFOV);
		}
		Target.position += Vector3.up * yValue * YSpeed * getFOVModification(YSpeedModifierFOV);
		Quaternion lhs = Quaternion.AngleAxis(Input.GetAxis("RightHorizontal") * XSensitivity * getFOVModification(RotationModifierFOV), Vector3.up);
		Target.transform.rotation = lhs * Target.transform.rotation;
		Quaternion rhs = Quaternion.AngleAxis(Input.GetAxis("RightVertical") * YSensitivity * getFOVModification(RotationModifierFOV), Vector3.right);
		Target.transform.rotation = Target.transform.rotation * rhs;
		if (Input.GetButton("LeftBumper"))
		{
			Camera.fieldOfView += Input.GetAxis("LeftBumper") * FOVSensitivity;
		}
		if (Input.GetButton("RightBumper"))
		{
			Camera.fieldOfView -= Input.GetAxis("RightBumper") * FOVSensitivity;
			if (Camera.fieldOfView < 1f)
			{
				Camera.fieldOfView = 1f;
			}
		}
		if (Input.GetButton("DPadLeft"))
		{
			Quaternion lhs2 = Quaternion.AngleAxis(ZSensitivity, Target.forward);
			Target.transform.rotation = lhs2 * Target.transform.rotation;
		}
		if (Input.GetButton("DPadRight"))
		{
			Quaternion lhs2 = Quaternion.AngleAxis(0f - ZSensitivity, Target.forward);
			Target.transform.rotation = lhs2 * Target.transform.rotation;
		}
		if (Input.GetButtonDown("DPadUp"))
		{
			Vector3 eulerAngles = Target.transform.rotation.eulerAngles;
			eulerAngles.z = 0f;
			Quaternion lhs2 = Quaternion.Euler(eulerAngles);
			Target.transform.rotation = lhs2;
		}
		if (Input.GetButtonDown("StartButton"))
		{
			Service.Get<TweakerConsoleController>().gameObject.SetActive(value: true);
		}
		if (Input.GetButtonDown("BButton"))
		{
			Service.Get<TweakerConsoleController>().gameObject.SetActive(value: false);
		}
		if (Input.GetButtonDown("XButton"))
		{
			WorldRelativeZMotion = !WorldRelativeZMotion;
		}
		if (Input.GetButtonDown("YButton"))
		{
			setLocalPlayerActive(!isLocalPlayerActive);
		}
	}

	private float getFOVModification(float modifier)
	{
		float num = ((Camera.fieldOfView - 60f) / 60f + 1f) * modifier;
		if (Math.Abs(num) > 1.401298E-45f)
		{
			return num;
		}
		return 1f;
	}

	[Invokable("FreeCamera.StartCamera", Description = "Sets camera to free camera mode. Try plugging in a game controller. * This was used for in-game video capture")]
	[PublicTweak]
	public static void StartCamera()
	{
		Transform transform = Service.Get<GameObject>().transform;
		if (transform.Find("FreeCameraTarget") == null)
		{
			GameObject gameObject = new GameObject("FreeCameraTarget");
			gameObject.transform.SetParent(transform, worldPositionStays: false);
			gameObject.transform.position = Camera.main.transform.position;
			gameObject.transform.rotation = Camera.main.transform.rotation;
			FreeCameraController freeCameraController = gameObject.AddComponent<FreeCameraController>();
			freeCameraController.Target = gameObject.transform;
		}
	}

	[Invokable("FreeCamera.StopCamera", Description = "Stops free camera mode.")]
	[PublicTweak]
	public static void StopCamera()
	{
		Transform transform = Service.Get<GameObject>().transform.Find("FreeCameraTarget");
		if (transform != null)
		{
			UnityEngine.Object.Destroy(transform.gameObject);
		}
	}

	private void setLocalPlayerActive(bool isActive)
	{
		isLocalPlayerActive = isActive;
		if (localPlayerMask != 0 && localPlayerMask != -1)
		{
			if (isActive)
			{
				Camera.cullingMask |= 1 << localPlayerMask;
			}
			else
			{
				Camera.cullingMask &= ~(1 << localPlayerMask);
			}
		}
		if (blobShadowCaster != null)
		{
			blobShadowCaster.SetIsActive(isActive);
		}
	}

	private void OnDestroy()
	{
		if (context != null)
		{
			context.SendEvent(new ExternalEvent("Root", "restoreUI"));
		}
		Service.Get<EventDispatcher>().DispatchEvent(default(PlayerNameEvents.ShowPlayerNames));
		if (worldChatCanvas != null)
		{
			worldChatCanvas.worldCamera = mainCamera;
		}
		if (groupCulling != null)
		{
			groupCulling.enabled = true;
		}
		mainCamera.enabled = true;
		setLocalPlayerActive(isActive: true);
	}
}
