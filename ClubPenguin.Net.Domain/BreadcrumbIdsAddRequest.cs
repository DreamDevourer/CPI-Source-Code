// BreadcrumbIdsAddRequest
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public struct BreadcrumbIdsAddRequest
{
	public List<Breadcrumb> Breadcrumbs;
}
