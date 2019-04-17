// ScheduledEventServiceEvents
using ClubPenguin.Net.Domain.ScheduledEvent;

public static class ScheduledEventServiceEvents
{
	public struct CFCDonationPosted
	{
		public DonationResult DonationResult;

		public CFCDonationPosted(DonationResult donationResult)
		{
			DonationResult = donationResult;
		}
	}

	public struct CFCDonationsLoaded
	{
		public CFCDonations CFCDonations;

		public CFCDonationsLoaded(CFCDonations cfcDonations)
		{
			CFCDonations = cfcDonations;
		}
	}
}
