// ITaskService
using ClubPenguin.Net;
using UnityEngine;

public interface ITaskService : INetworkService
{
	void Pickup(string path, string tag, Vector3 position);

	void ClaimReward(string taskId);
}
