// BreadcrumbCollection
using ClubPenguin.Net.Domain;
using ClubPenguin.Net.Offline;
using System.Collections.Generic;

public struct BreadcrumbCollection : IOfflineData
{
	public List<Breadcrumb> breadcrumbs;

	public void Init()
	{
		breadcrumbs = new List<Breadcrumb>();
	}
}
