// PCGetProductDetailsResponse
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public struct PCGetProductDetailsResponse
{
	public PCProduct Product;

	public PCContext Context;
}
