// IBreadcrumbService
using ClubPenguin.Net;
using ClubPenguin.Net.Domain;
using System.Collections.Generic;

public interface IBreadcrumbService : INetworkService
{
	void AddBreadcrumbIds(List<Breadcrumb> breadcrumbIds);

	void RemoveBreadcrumbIds(List<Breadcrumb> breadcrumbIds);
}
