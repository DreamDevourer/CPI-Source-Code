// PermissionNotRequiredResult
using Disney.Mix.SDK;

public class PermissionNotRequiredResult : IPermissionNotRequiredResult, IPermissionResult
{
	public bool Success => true;

	public ActivityApprovalStatus Status => ActivityApprovalStatus.Approved;
}
