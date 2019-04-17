// PermissionFailedInvalidResult
using Disney.Mix.SDK;

public class PermissionFailedInvalidResult : IPermissionFailedInvalidResult, IPermissionResult
{
	public bool Success => false;

	public ActivityApprovalStatus Status => ActivityApprovalStatus.Unknown;
}
