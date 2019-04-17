// NewsfeedServiceEvents
public static class NewsfeedServiceEvents
{
	public struct LatestPostTime
	{
		public readonly int Timestamp;

		public LatestPostTime(int timestamp)
		{
			Timestamp = timestamp;
		}
	}
}
