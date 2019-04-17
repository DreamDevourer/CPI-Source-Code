// BreadcrumbServiceEvents
using ClubPenguin.Net.Domain;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public static class BreadcrumbServiceEvents
{
	public struct BreadcrumbIdsReceived
	{
		public readonly List<Breadcrumb> BreadcrumbIds;

		public BreadcrumbIdsReceived(List<Breadcrumb> breadcrumbIds)
		{
			BreadcrumbIds = breadcrumbIds;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct BreadcrumbIdsAdded
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct BreadcrumbIdsRemoved
	{
	}
}
