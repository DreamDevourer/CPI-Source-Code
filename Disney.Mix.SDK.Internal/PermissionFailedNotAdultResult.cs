// PermissionFailedNotAdultResult
using Disney.Mix.SDK;

public class PermissionFailedNotAdultResult : IPermissionFailedNotAdultResult, IPermissionResult
{
	public bool Success => false;

	public ActivityApprovalStatus Status => ActivityApprovalStatus.Unknown;
}
