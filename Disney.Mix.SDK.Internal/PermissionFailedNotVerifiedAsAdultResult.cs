// PermissionFailedNotVerifiedAsAdultResult
using Disney.Mix.SDK;

public class PermissionFailedNotVerifiedAsAdultResult : IPermissionFailedNotVerifiedAsAdultResult, IPermissionResult
{
	public bool Success => false;

	public ActivityApprovalStatus Status => ActivityApprovalStatus.Unknown;
}
