// PermissionResult
using Disney.Mix.SDK;

public class PermissionResult : IPermissionResult
{
	public bool Success
	{
		get;
		private set;
	}

	public ActivityApprovalStatus Status
	{
		get;
		private set;
	}

	public PermissionResult(bool success, ActivityApprovalStatus status)
	{
		Success = success;
		Status = status;
	}
}
