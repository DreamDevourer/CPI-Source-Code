// TrayNotificationCelebration
using ClubPenguin;
using ClubPenguin.Adventure;
using ClubPenguin.Task;
using ClubPenguin.UI;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class TrayNotificationCelebration : TrayNotification
{
	public Image MascotImage;

	public ParticleSystem ParticlesToTint;

	public override void Show(DNotification data)
	{
		base.Show(data);
		Task task = (Task)data.DataPayload;
		if (task != null)
		{
			string subGroupByTaskName = Service.Get<TaskService>().GetSubGroupByTaskName(task.Id);
			Mascot mascot = Service.Get<MascotService>().GetMascot(subGroupByTaskName);
			MascotImage.color = mascot.Definition.NavigationArrowColor;
			if (ParticlesToTint != null)
			{
				ParticlesToTint.SetStartColor(mascot.Definition.NavigationArrowColor);
			}
			messageWithoutButtons.color = mascot.Definition.NavigationArrowColor;
			if (data.Type == DNotification.NotificationType.DailyComplete)
			{
				DailyChallengesListItem.ClaimDailyTaskReward(task);
			}
		}
	}
}
