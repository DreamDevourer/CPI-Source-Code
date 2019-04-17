// PermissionAlreadyApprovedResult
using Disney.Mix.SDK;

public class PermissionAlreadyApprovedResult : IPermissionResult
{
	public bool Success => true;

	public ActivityApprovalStatus Status => ActivityApprovalStatus.Approved;
}
