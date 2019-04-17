// TaskServiceEvents
using ClubPenguin.Task;
using System.Collections.Generic;

public static class TaskServiceEvents
{
	public struct TasksLoaded
	{
		public readonly Dictionary<string, Task> Tasks;

		public TasksLoaded(Dictionary<string, Task> tasks)
		{
			Tasks = tasks;
		}
	}
}
