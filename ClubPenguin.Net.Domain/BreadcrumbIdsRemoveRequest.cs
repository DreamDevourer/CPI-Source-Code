// BreadcrumbIdsRemoveRequest
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public struct BreadcrumbIdsRemoveRequest
{
	public List<Breadcrumb> BreadcrumbIds;
}
