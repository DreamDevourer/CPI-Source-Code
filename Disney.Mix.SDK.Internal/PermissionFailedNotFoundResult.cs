// PermissionFailedNotFoundResult
using Disney.Mix.SDK;

public class PermissionFailedNotFoundResult : IPermissionFailedNotFoundResult, IPermissionResult
{
	public bool Success => false;

	public ActivityApprovalStatus Status => ActivityApprovalStatus.Unknown;
}
