// PermissionFailedAlreadyDeniedResult
using Disney.Mix.SDK;

public class PermissionFailedAlreadyDeniedResult : IPermissionFailedAlreadyDeniedResult, IPermissionResult
{
	public bool Success => false;

	public ActivityApprovalStatus Status => ActivityApprovalStatus.Denied;
}
