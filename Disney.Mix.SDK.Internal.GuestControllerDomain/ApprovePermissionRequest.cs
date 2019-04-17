// ApprovePermissionRequest
using Disney.Mix.SDK.Internal;

public class ApprovePermissionRequest : AbstractGuestControllerWebCallRequest
{
	public string activityCode
	{
		get;
		set;
	}

	public bool blanketApproved
	{
		get;
		set;
	}

	public string dateRequested
	{
		get;
		set;
	}

	public string activityPermimssionGuid
	{
		get;
		set;
	}

	public string approvalStatus
	{
		get;
		set;
	}

	public string swid
	{
		get;
		set;
	}
}
